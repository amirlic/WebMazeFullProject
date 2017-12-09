using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using System.Net;
using System.IO;
using System.Threading;
using System.Configuration;
using MazeLib;
using System.ComponentModel;

namespace ClientProj
{
    public delegate void command(string command);
    public class Client : INotifyPropertyChanged
    {
        public event command cm;
        private Position myLocation;
        private Position otherLocation;
        private Position finishLocation;
        private Maze maze;
        private TcpClient client;

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        public Client()
        {

        }

        public Position MyLocation
        {
            get { return myLocation; }
            set
            {
                myLocation = value;
                NotifyPropertyChanged("MyLocation");
            }
        }
        public Position OtherLocation
        {
            get { return otherLocation; }
            set
            {
                otherLocation = value;
                NotifyPropertyChanged("OtherLocation");
            }
        }
        public Position FinishLocation
        {
            get { return finishLocation; }
            set
            {
                finishLocation = value;
                NotifyPropertyChanged("FinishLocation");
            }
        }

        public void Right()
        {
            //this.Command("Play Right");
            this.myLocation = new Position(this.myLocation.Row, this.myLocation.Col + 1);
        }

        public void Left()
        {
            //this.Command("Play Left");
            this.myLocation = new Position(this.myLocation.Row, this.myLocation.Col - 1);
        }

        public void Down()
        {
            //this.Command("Play Down");
            this.myLocation = new Position(this.myLocation.Row + 1, this.myLocation.Col);
        }

        public void Up()
        {
            //this.Command("Play Up");
            this.myLocation = new Position(this.myLocation.Row - 1, this.myLocation.Col);
        }

        public void InitMyLocation() { myLocation = maze.InitialPos; }

        public void InitOtherLocation() { otherLocation = maze.InitialPos; }

        public void InitFinishLocation() { finishLocation = maze.GoalPos; }

        public string Command(string command)
        {
            string ans = Start(command);
            InitMyLocation();
            InitFinishLocation();
            InitOtherLocation();
            return ans;
        }
        public string getList()
        {
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8000);

            string request = "";
            string answer = "";
            bool endGame = false;
            request = "list";

            this.client = new TcpClient();
            this.client.Connect(ep);
            Console.WriteLine("You are connected");

            NetworkStream stream = client.GetStream();
            BinaryReader reader = new BinaryReader(stream);
            BinaryWriter writer = new BinaryWriter(stream);



            writer.Write(request);
            writer.Flush();
            answer = reader.ReadString();
            client.Close();
            return answer;

        }

        public string Start(string command)
        {
            //IPEndPoint ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"),
            //int.Parse(ConfigurationManager.AppSettings["port"]));
            //the visual dont recognize this...

            IPEndPoint ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8000);

            string request = "";
            string answer = "";
            bool endGame = false;

            while (true)
            {
                Console.WriteLine("please enter First command to the server ");
                //request = Console.ReadLine();
                request = command;

                this.client = new TcpClient();
                this.client.Connect(ep);
                Console.WriteLine("You are connected");

                NetworkStream stream = client.GetStream();
                BinaryReader reader = new BinaryReader(stream);
                BinaryWriter writer = new BinaryWriter(stream);

                endGame = false;

                writer.Write(request);
                writer.Flush();

                if ((request.StartsWith("close") || request.StartsWith("join") ||
                request.StartsWith("play") || request.StartsWith("list") ||
                request.StartsWith("start")) && !endGame)
                {
                    Task recive = new Task(() =>
                    {
                        while (!answer.Equals("close") && !endGame)
                        {
                            BinaryReader readerer = new BinaryReader(stream);

                            Console.WriteLine("Wait for ANSWER");
                            answer = readerer.ReadString();
                            Console.WriteLine("server answered to = {0}", answer);
                        }
                        Console.WriteLine("EndReciveTASK");
                        endGame = true;
                    });
                    recive.Start();
                    if (endGame) { recive.Wait(); }

                    Task send = new Task(() =>
                    {
                        while ((!request.StartsWith("close") || answer.StartsWith("close")) && !endGame)
                        {
                            BinaryWriter writerer = new BinaryWriter(stream);
                            Console.WriteLine("please enter command to the server ");
                            request = Console.ReadLine();
                            Console.WriteLine("SENDING");
                            writerer.Write(request);
                            writerer.Flush();
                        }
                        Console.WriteLine("EndSendTask");
                        endGame = true;
                    });
                    send.Start();
                    send.Wait();
                }
                else
                {
                    answer = reader.ReadString();
                    if (request.StartsWith("generate"))
                    {
                        this.maze = Maze.FromJSON(answer);
                    }
                    else
                    {

                        System.Console.WriteLine("{0}", answer);
                        answer = answer.Substring(answer.IndexOf("o") + 10, answer.IndexOf('"', answer.IndexOf("o") + 11) - answer.IndexOf("o") + 10);
                        answer = answer.Substring(1);
                        answer = answer.Substring(0, answer.Length - 20);
                    }
                    Console.WriteLine("server SinglePlayer answered to = {0}", answer);
                    endGame = true;
                    client.Close();
                    return answer;
                }
            }

        }
    }
}
