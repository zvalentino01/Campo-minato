using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Net;
using System.Net.Sockets;
using System.Threading;


namespace Minefield_Online
{
    public enum appType {Client,Server}
    public partial class Main : Form
    {
        
        #region Variables
            public appType appType;
            public Settings settings;
            public PlayerNames playerNames;
            public Informations informations;
            public Players player;
            public String playerName;

            #region Server
                private TcpListener server;
                private Thread serverThread;
                private TcpClient[] clients;
                private Thread[] clientThreads;
                private NetworkStream[] clientStreams;
                private Minefield minefield;
            #endregion

            #region Client
                NetworkStream clientStream;
                TcpClient client;
                Thread clientThread;
                public string serverAddress;
                public ushort serverPort;
            #endregion

            private delegate void networkCommands();
            private delegate void networkTextCommands(String text);
            private delegate void networkMineCommands(MineInfo tMineInfo);
        #endregion

        public Main() {
            InitializeComponent();
        }

        private void SetupSettingsDisplay() {
            if (informations.Connected < settings.Players) {
                info_players.Text = informations.Connected+ "/" + settings.Players;
            } else {
                info_players.Text = informations.Connected.ToString();
            }

            info_turn.Text = informations.PlayersTurn.ToString();//General.GetPlayersName(informations.PlayersTurn, playerNames);

            info_player1.ForeColor = General.PlayerColors[0];
            info_player2.ForeColor = General.PlayerColors[1];
            info_player3.ForeColor = General.PlayerColors[2];
            info_player4.ForeColor = General.PlayerColors[3];

            info_player1.Text = playerNames.Player1Name + "(" + informations.Player1Points + ")";
            info_player2.Text = playerNames.Player2Name + "(" + informations.Player2Points + ")";
            info_player3.Text = playerNames.Player3Name + "(" + informations.Player3Points + ")";
            info_player4.Text = playerNames.Player4Name + "(" + informations.Player4Points + ")";

            if (settings.Players ==4) {
                info_player3.Visible = true;
                info_player4.Visible = true;
            }else if(settings.Players ==3){
                info_player3.Visible = true;
                info_player4.Visible = false;
            }else{
                info_player3.Visible = false;
                info_player4.Visible = false;
            }
            info_group.Visible = true;
        }
       
        private void _menu_toogleChat_Click(object sender, EventArgs e)
        {   
            if (chat_group.Visible) {
                this.Size = new Size(this.Size.Width, this.Size.Height - 135);
            }else{

                this.Size = new Size(this.Size.Width, this.Size.Height + 135);
            }
            chat_group.Visible = !chat_group.Visible;
      
        }

        private void DrawMinefield() {
            field_group.Controls.Clear();
            this.Size = new System.Drawing.Size(settings.Horizontal<14?350:settings.Horizontal * 24 + 15, settings.Vertical * 24 + (chat_group.Visible?260:125));

            for (ushort i = 0; i < settings.Horizontal; i++) {
                for (ushort j = 0; j < settings.Vertical; j++) {
                    Mine newMine = new Mine(i, j);
                    newMine.Name = "Mine_" + i + "_" + j;
                    newMine.Size = new Size(24, 24);
                    newMine.Text = null;
                    newMine.Font = new System.Drawing.Font(newMine.Font.FontFamily, 10f, FontStyle.Bold);
                    newMine.Location = new Point(i * 24+5, j * 24+10);
                    newMine.Enabled = false;
                //    newMine.FlatStyle = FlatStyle.Flat;
                    newMine.MouseDown += new MouseEventHandler(newMine_MouseDown);
                    field_group.Controls.Add(newMine);
                }
            }
        }

        void newMine_MouseDown(object sender, MouseEventArgs e) {
            if (sender.GetType() == typeof(Mine)) {
                Mine tMine = (Mine)sender;
                if (tMine.open == false) {
                    MineInfo tMineInfo;
                    tMineInfo.x = tMine.x;
                    tMineInfo.y = tMine.y;
                    tMineInfo.bomb = tMine.bomb;
                    if(tMine.bomb)
                        System.Media.SystemSounds.Exclamation.Play();
                    tMineInfo.count = tMine.count;
                    tMineInfo.player = player;
                    foreach (Control C in field_group.Controls) {
                        C.Enabled = false;
                    }
                    Played(tMineInfo);
                }
            }
        }
        void NextPlayer() {
            if (informations.PlayersTurn == Players.Player1) {
                informations.PlayersTurn = Players.Player2;
            }else if(informations.PlayersTurn == Players.Player2){
                if (settings.Players == 2) {
                    informations.PlayersTurn = Players.Player1;
                }else{
                    informations.PlayersTurn = Players.Player3;
                }
            } else if (informations.PlayersTurn == Players.Player3) {
                if (settings.Players == 3) {
                    informations.PlayersTurn = Players.Player1;
                } else {
                    informations.PlayersTurn = Players.Player4;
                }
            } else if (informations.PlayersTurn == Players.Player4) {
                informations.PlayersTurn = Players.Player1;
            }
            SetupSettingsDisplay();
            Command cmd;
            cmd.command = Commands.sendInfo;
            cmd.extraDataLength = Network.InformationsSize;
            for (ushort i = 0; i < settings.Players - 1; i++) {
                SendCommandToClient(i, cmd, Network.SerializeStruct<Informations>(informations));
            }
            cmd.command = Commands.play;
            cmd.extraDataLength=0;
            switch (informations.PlayersTurn) {
                case Players.Player1:
                    Play();
                    break;
                case Players.Player2:
                    SendCommandToClient(0, cmd, null);
                    break;
                case Players.Player3:
                    SendCommandToClient(1, cmd, null);
                    break;
                case Players.Player4:
                    SendCommandToClient(2, cmd, null);
                    break;
            }
        }

        void Played(MineInfo tMineInfo) {
            Command cmd;
            if (appType == Minefield_Online.appType.Server) {

                tMineInfo.bomb = minefield.Mines[tMineInfo.x, tMineInfo.y].bomb;
                tMineInfo.count = minefield.Mines[tMineInfo.x, tMineInfo.y].count;

                if (tMineInfo.bomb) {
                    if (tMineInfo.player == Players.Player1) {
                        informations.Player1Points += 1;
                    } else if (tMineInfo.player == Players.Player2) {
                        informations.Player2Points += 1;
                    } else if (tMineInfo.player == Players.Player3) {
                        informations.Player3Points += 1;
                    } else if (tMineInfo.player == Players.Player4) {
                        informations.Player4Points += 1;
                    }
                    field_group.Controls["Mine_" + tMineInfo.x +"_" + tMineInfo.y].Text = "B";
                } else {
                    field_group.Controls["Mine_" + tMineInfo.x +"_" + tMineInfo.y].Text = tMineInfo.count.ToString();
                }
                if (tMineInfo.player != Players.None) {
                    field_group.Controls["Mine_" + tMineInfo.x + "_" + tMineInfo.y].ForeColor = General.PlayerColors[(int)tMineInfo.player - 1];
                }
                if (tMineInfo.count == 0) {
                    minefield.checkForEmpty(minefield.Mines[tMineInfo.x, tMineInfo.y]);
                }
                ((Mine)field_group.Controls["Mine_" + tMineInfo.x + "_" + tMineInfo.y]).open = true;
                minefield.Mines[tMineInfo.x, tMineInfo.y].open = true;
                cmd.command = Commands.played;
                cmd.extraDataLength = Network.MineInfoSize;

                for (ushort i = 0; i < settings.Players - 1; i++) {
                    SendCommandToClient(i, cmd, Network.SerializeStruct<MineInfo>(tMineInfo));
                }
                if (minefield.GameOver()) {
                    ServerGameOver();
                } else {
                    NextPlayer();
                }
            } else {
                tMineInfo.bomb = false;
                tMineInfo.count =0;

                cmd.command = Commands.played;
                cmd.extraDataLength = Network.MineInfoSize;
                SendCommandToServer(cmd, Network.SerializeStruct<MineInfo>(tMineInfo));
            }
        }
        void ServerGameOver() {
            //Find winner
            Players winner = Players.Player1;
            ushort points = informations.Player1Points;
            if(informations.Player2Points > points)
                winner = Players.Player2;
            if (informations.Player3Points > points)
                winner = Players.Player3;
            if (informations.Player4Points > points)
                winner = Players.Player4;
            String msg = "Game over !!! Player { " + winner.ToString() + "} : " + General.GetPlayersName(winner, playerNames) + " with " + points + " points !\n";
            SendTextToClients(msg);
            informations.Player1Points = informations.Player2Points = informations.Player3Points = informations.Player4Points = 0;
            DrawMinefield();
            ClientConnected();
            ReadyServer();
        }
        void ReceivePlayed(MineInfo tMineInfo) {
            if (tMineInfo.bomb) {
                field_group.Controls["Mine_" + tMineInfo.x + "_" + tMineInfo.y].Text = "B";
            }else{
                field_group.Controls["Mine_" + tMineInfo.x + "_" + tMineInfo.y].Text = tMineInfo.count.ToString();
            }
            if (tMineInfo.player != Players.None) {
                field_group.Controls["Mine_" + tMineInfo.x + "_" + tMineInfo.y].ForeColor = General.PlayerColors[(int)tMineInfo.player - 1];
            }
            ((Mine)field_group.Controls["Mine_" + tMineInfo.x + "_" + tMineInfo.y]).open = true;
        }
        private void _menu_connect_Click(object sender, EventArgs e) {
            if (new ConnectForm(this).ShowDialog(this) == System.Windows.Forms.DialogResult.OK) {
                client = new TcpClient();
                try {
                    client.Connect(serverAddress, (int)serverPort);
                } catch (Exception ex) {
                    MessageBox.Show("Cannot connect to server \n" + ex.Message);
                    return;
                }
                _menu_createServer.Enabled = _menu_connect.Enabled = false;

                appType = Minefield_Online.appType.Client;
                clientThread = new Thread(new ThreadStart(ListeningClient));
                clientThread.Start();
                EnableChat();
            }
        }
        private void EnableChat() {
            chat_text.Enabled = chat_send.Enabled = true;
        }
        private void _menu_createServer_Click(object sender, EventArgs e)
        {
            if (new CreateForm(this).ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                player = Players.Player1;
                playerNames.Player1Name = playerName;
                playerNames.Player2Name = "Player2";
                playerNames.Player3Name = "Player3";
                playerNames.Player4Name = "Player4";
                informations.Connected = 1;
                informations.PlayersTurn = Players.None;
                informations.Player1Points = informations.Player2Points = informations.Player3Points = informations.Player4Points = 0;
                appType = Minefield_Online.appType.Server;
                SetupSettingsDisplay();
                
                _menu_createServer.Enabled = _menu_connect.Enabled = false;

                this.Text += " [Server running at port " +settings.ServerPort + "]";

                server = new TcpListener(IPAddress.Any, (int)settings.ServerPort);
                serverThread = new Thread(new ThreadStart(LiseningForClient));
                serverThread.Start();
                EnableChat();
                DrawMinefield();
            }
        }
        private void ListeningClient() {

            Command cmd;
            cmd.command = Commands.connect;
            cmd.extraDataLength = (ushort)System.Text.Encoding.Default.GetByteCount(playerName);

            byte[] buffer = Network.SerializeStruct<Command>(cmd);
            byte[] extra;

            clientStream = client.GetStream();
            clientStream.Write(buffer, 0, buffer.Length);
            extra = System.Text.Encoding.Default.GetBytes(playerName);
            clientStream.Write(extra, 0, extra.Length);
            buffer = new byte[Network.CommandSize];
            MineInfo tMineInfo;
            while (true) {
                clientStream.Read(buffer, 0, Network.CommandSize);
                cmd = Network.DeSerializeStruct<Command>(buffer);

                 Console.WriteLine("Command received : {0}", cmd.command.ToString());
                 switch (cmd.command) {
                     case Commands.sendPlayer:
                         extra = new byte[cmd.extraDataLength];
                         clientStream.Read(extra, 0, cmd.extraDataLength);
                         player = General.ParseEnumValue<Players>((ushort)(((int)extra[0]) + 1));
                         extra = null;
                         break;
                     case Commands.sendSettings:
                         extra = new byte[cmd.extraDataLength];
                         clientStream.Read(extra, 0, cmd.extraDataLength);
                         settings = Network.DeSerializeStruct<Settings>(extra);
                         extra = null;
                         this.Invoke(new networkCommands(this.SetupSettingsDisplay));
                         this.Invoke(new networkCommands(this.DrawMinefield));
                         break;
                     case Commands.sendInfo:
                         extra = new byte[cmd.extraDataLength];
                         clientStream.Read(extra, 0, cmd.extraDataLength);
                         informations = Network.DeSerializeStruct<Informations>(extra);
                         extra = null;
                         this.Invoke(new networkCommands(this.SetupSettingsDisplay));
                         break;
                     case Commands.sendName:
                         extra = new byte[cmd.extraDataLength];
                         clientStream.Read(extra, 0, cmd.extraDataLength);
                         playerNames = Network.DeSerializeStruct<PlayerNames>(extra);
                         extra = null;
                         this.Invoke(new networkCommands(this.SetupSettingsDisplay));
                         break;
                     case Commands.play:
                         this.Invoke(new networkCommands(this.Play));
                         break;
                     case Commands.played:
                         extra = new byte[cmd.extraDataLength];
                         clientStream.Read(extra, 0, cmd.extraDataLength);
                         tMineInfo = Network.DeSerializeStruct<MineInfo>(extra);
                         extra = null;
                         this.Invoke(new networkMineCommands(this.ReceivePlayed),new Object[] {tMineInfo});
                         break;
                     case Commands.sendText:
                         extra = new byte[cmd.extraDataLength];
                         clientStream.Read(extra, 0, cmd.extraDataLength);
                         this.Invoke(new networkTextCommands(this.writeToChat),new object[] { System.Text.Encoding.Default.GetString(extra)});
                         extra = null;                         
                         break;
                 }
            }
        
        }
        private void LiseningForClient() {
            server.Start();
            clientThreads = new Thread[settings.Players - 1];
            clients = new TcpClient[settings.Players - 1];
            clientStreams = new NetworkStream[settings.Players - 1];
            for (ushort i = 0; i < settings.Players-1; i++) {
                clients[i] = server.AcceptTcpClient();
                Console.WriteLine("Thead running for index {0}", i);
                clientThreads[i] = new Thread(new ParameterizedThreadStart(HandleClient));
                clientThreads[i].Start(i);
                informations.Connected += 1;
            }
            ReadyServer();
        }
        private void ReadyServer() {
            minefield = new Minefield();
            minefield.Setup(settings.Horizontal, settings.Vertical, settings.Bombs);
            minefield.MineCheckEvent += new Minefield.MineCheckHandler(minefield_MineCheckEvent);
            // DrawMinefield();
            informations.PlayersTurn = Players.Player1;
            Command cmd;
            cmd.command = Commands.sendInfo;
            cmd.extraDataLength = Network.InformationsSize;
            for (ushort i = 0; i < settings.Players - 1; i++) {
               SendCommandToClient(i, cmd, Network.SerializeStruct<Informations>(informations));
            }
            this.Invoke(new networkCommands(SetupSettingsDisplay));
            //Allow Play
            this.Invoke(new networkCommands(Play));
        }

        void minefield_MineCheckEvent(MineEventArgs e) {
            Played(e.tMineInfo);
        }
        private void ClientConnected() {
            Command cmd;
            cmd.command = Commands.sendPlayer;
            cmd.extraDataLength = sizeof(byte);
            for (ushort i = 0; i < settings.Players-1; i++) {
                if (clientStreams[i] != null) SendCommandToClient(i, cmd, new byte[] { (byte)General.ParseEnumValue<Players>((ushort)(i + 1)) });
            }
            cmd.command = Commands.sendSettings;
            cmd.extraDataLength = Network.SettingsSize;
            for (ushort i = 0; i < settings.Players - 1; i++) {
                if (clientStreams[i] != null) SendCommandToClient(i, cmd, Network.SerializeStruct<Settings>(settings));
            }
            cmd.command = Commands.sendInfo;
            cmd.extraDataLength = Network.InformationsSize;
            for (ushort i = 0; i < settings.Players - 1; i++) {
                if(clientStreams[i]!=null) SendCommandToClient(i, cmd, Network.SerializeStruct<Informations>(informations));
            }
            SetupSettingsDisplay();
            //cmd.command = Commands.sendName;
            //cmd.extraDataLength = Network.PlayerNamesSize;
            //for (ushort i = 0; i < settings.Players - 1; i++) {
            //    if (clientStreams[i] != null) SendCommandToClient(i, cmd, Network.SerializeStruct<PlayerNames>(playerNames));
            //}
        }
        private void HandleClient(object OBJindex) {
            ushort index = (ushort)OBJindex;
            Players _player = General.ParseEnumValue<Players>((ushort)(index + 1));
            clientStreams[index] = clients[index].GetStream();
            Command cmd;
            byte[] data = new byte[Network.CommandSize];
            byte[] extra;
            Boolean running=true;
            while (running) {
                clientStreams[index].Read(data, 0, Network.CommandSize);
                cmd = Network.DeSerializeStruct<Command>(data);

                Console.WriteLine("Command received : {0}", cmd.command.ToString());
                switch (cmd.command) {
                    case Commands.connect: //Client Connected;
                        extra = new byte[cmd.extraDataLength];
                        clientStreams[index].Read(extra, 0, cmd.extraDataLength);

                        if(index==0){
                            playerNames.Player2Name = System.Text.Encoding.Default.GetString(extra);
                        }else if(index==1){
                            playerNames.Player3Name = System.Text.Encoding.Default.GetString(extra);
                        }else if(index==2){
                            playerNames.Player4Name = System.Text.Encoding.Default.GetString(extra);
                        }
                        this.Invoke(new networkTextCommands(writeToChat), new object[] { "Client connected " + System.Text.Encoding.Default.GetString(extra) + "\n" });
                        this.Invoke(new networkCommands(ClientConnected));
                        extra = null;
                        break;
                    case Commands.disconnect:
                        running = false;
                        break;
                    case Commands.played:
                        extra = new byte[cmd.extraDataLength];
                        clientStreams[index].Read(extra, 0, cmd.extraDataLength);
                        this.Invoke(new networkMineCommands(Played), new Object[] { Network.DeSerializeStruct<MineInfo>(extra) });
                        extra = null;
                        break;
                    case Commands.sendText:
                        extra = new byte[cmd.extraDataLength];
                        clientStreams[index].Read(extra, 0, cmd.extraDataLength);
                        this.Invoke(new networkTextCommands(SendTextToClients), new Object[] { General.GetPlayersName(_player, playerNames) + ": " + System.Text.Encoding.Default.GetString(extra) + "\n" });
                        extra = null;
                        break;
                }
            }
            clients[index].Close();
        }
        private void SendTextToClients(String text) {
            writeToChat(text);
            Command cmd;
            cmd.command = Commands.sendText;
            cmd.extraDataLength = (ushort)System.Text.Encoding.Default.GetByteCount(text);
            for (ushort i = 0; i < settings.Players - 1; i++) {
                if (clientStreams[i] != null) SendCommandToClient(i, cmd, System.Text.Encoding.Default.GetBytes(text));
            }
        }
        private void SendCommandToClient(ushort index,Command cmd, byte[] extra) {
            byte[] data = Network.SerializeStruct<Command>(cmd);
            clientStreams[index].Write(data, 0, Network.CommandSize);
            if (cmd.extraDataLength > 0) {
                clientStreams[index].Write(extra, 0, (int)cmd.extraDataLength);
            }
            Console.WriteLine("Command send : {0}", cmd.command.ToString());
        }

        private void SendCommandToServer(Command cmd, byte[] extra) {
            byte[] data = Network.SerializeStruct<Command>(cmd);
            clientStream.Write(data, 0, Network.CommandSize);
            if (cmd.extraDataLength > 0) {
                clientStream.Write(extra, 0, (int)cmd.extraDataLength);
            }
            Console.WriteLine("Command send : {0}", cmd.command.ToString());
        }

        private void writeToChat(string text) {
            chat.AppendText(text);
        }

        private void Main_Load(object sender, EventArgs e) {
            
            _menu_toogleChat_Click(null, null);
        }
        private void Play() {
            System.Media.SystemSounds.Beep.Play();
            foreach (Control c in field_group.Controls) {
                if (c.GetType() == typeof(Mine)) {
                    Mine tMine = (Mine)c;
                    //if (!tMine.open) {
                        tMine.Enabled = true;
                    //}
                }
            }
        }
        private void _menu_exit_Click(object sender, EventArgs e) {
            if (appType == Minefield_Online.appType.Client) {
                if (clientStream != null) clientStream.Close();
                if (client != null) client.Close();
                if(clientThread!=null) clientThread.Abort();
            } else {
                if (clientStreams != null) {
                    for (int i = clientStreams.Length - 1; i < 0; i--) {
                        if(clientStreams[i]!=null)clientStreams[i].Close();
                        if (clients[i] != null) clients[i].Close();
                        if (clientThreads[i] != null) { clientThreads[i].Abort(); clientThreads[i] = null; }
                    }
                    if(server!=null)server.Stop();
                    if (serverThread != null) {
                        serverThread.Abort();
                        serverThread = null;
                    }
                }
                    
            }
            _menu_createServer.Enabled = _menu_connect.Enabled = true;
        }

        private void chat_send_Click(object sender, EventArgs e) {
            if (appType == Minefield_Online.appType.Client) {
                 Command cmd;
                cmd.command= Commands.sendText;
                byte[] text = System.Text.Encoding.Default.GetBytes(chat_text.Text);
               
                cmd.extraDataLength= (ushort)text.Length;
                SendCommandToServer(cmd, text);
                text = null;
            } else {
                SendTextToClients(playerName + ": " + chat_text.Text + "\n");
            }
            chat_text.Text = null;
        }

        private void chat_text_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyData == Keys.Enter) {
                chat_send_Click(chat_send, null);
            }
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e) {
            _menu_exit_Click(null, null);
        }

    }
}
