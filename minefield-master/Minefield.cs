using System;

namespace Minefield_Online
{
    public class Minefield {
        public delegate void MineCheckHandler(MineEventArgs e);
        public event MineCheckHandler MineCheckEvent;

        private ushort _horizontal;
        private ushort _vertical;
        private ushort _bombs;

        public ushort Horizontal { get { return _horizontal; } }
        public ushort Vertical { get { return _vertical; } }
        public ushort Bombs { get { return _bombs; } }

        Mine[,] _mines;

        public Mine[,] Mines { get { return _mines; } }

        public Minefield() {

        }

        public void Setup(ushort hor, ushort ver, ushort bombs) {
            _horizontal = hor; _vertical = ver; _bombs = bombs;

            _mines = new Mine[_horizontal, _vertical];

            for (ushort i = 0; i < _horizontal; i++) {
                for (ushort j = 0; j < _vertical; j++) {
                    Mines[i, j] = new Mine(i, j);
                    Mines[i, j].Size = new System.Drawing.Size(25, 25);
                    Mines[i, j].Location = new System.Drawing.Point(i * 25, j * 25);
                    //Mines[i, j].Text = null;
                    //Mines[i, j].MouseDown += new MouseEventHandler(MouseClickHandler);
                }
            }
            ushort t = 0;
            Random g = new Random();
            while (t < _bombs) {
                ushort rX = (ushort)g.Next(0, _horizontal), rY = (ushort)g.Next(0, _vertical);
                if (!Mines[rX, rY].bomb) {
                    Mines[rX, rY].bomb = true;
                    addToNeigbours(Mines[rX, rY]);
                    t++;
                }
            }

        }
		public  bool GameOver(){
			 for (ushort i = 0; i < _horizontal; i++) {
                for (ushort j = 0; j < _vertical; j++) {
					if(Mines[i, j].bomb && !Mines[i,j].open)
						return false;
				}
			}
			return true;
		}

        private void addToNeigbours(Mine tMine) {
            int x = tMine.x, y = tMine.y;

            if (x - 1 >= 0 && y - 1 >= 0) _mines[x - 1, y - 1].count++;
            if (y - 1 >= 0) _mines[x, y - 1].count++;
            if (x + 1 < _horizontal && y - 1 >= 0) _mines[x + 1, y - 1].count++;
            if (x + 1 < _horizontal) _mines[x + 1, y].count++;
            if (x + 1 < _horizontal && y + 1 < _vertical) _mines[x + 1, y + 1].count++;
            if (y + 1 < _vertical) _mines[x, y + 1].count++;
            if (x - 1 >= 0 && y + 1 < _vertical) _mines[x - 1, y + 1].count++;
            if (x - 1 >= 0) _mines[x - 1, y].count++;
        }

        public void checkForEmpty(Mine tMine) {
            if (!tMine.open && !tMine.bomb) {
                tMine.open = true;
                tMine.Text = tMine.count.ToString();
                ushort x = tMine.x, y = tMine.y;

                MineInfo tMineInfo;
                tMineInfo.player = Players.None;
                tMineInfo.bomb = false;
                tMineInfo.count = tMine.count;
                tMineInfo.x = x;
                tMineInfo.y = y;

                try {
                    MineCheckEvent(new MineEventArgs(tMineInfo));
                } catch (Exception) { }

                if (tMine.count == 0) {
                    if (x - 1 >= 0 && y - 1 >= 0 && !_mines[x - 1, y - 1].bomb && !_mines[x - 1, y - 1].open) checkForEmpty(_mines[x - 1, y - 1]);
                    if (y - 1 >= 0 && !_mines[x, y - 1].bomb && !_mines[x, y - 1].open) checkForEmpty(_mines[x, y - 1]);
                    if (x + 1 < Horizontal && y - 1 >= 0 && !_mines[x + 1, y - 1].bomb && !_mines[x + 1, y - 1].open) checkForEmpty(_mines[x + 1, y - 1]);
                    if (x + 1 < Horizontal && !_mines[x + 1, y].bomb && !_mines[x + 1, y].open) checkForEmpty(_mines[x + 1, y]);
                    if (x + 1 < Horizontal && y + 1 < Vertical && !_mines[x + 1, y + 1].bomb && !_mines[x + 1, y + 1].open) checkForEmpty(_mines[x + 1, y + 1]);
                    if (y + 1 < Vertical && !_mines[x, y + 1].bomb && !_mines[x, y + 1].open) checkForEmpty(_mines[x, y + 1]);
                    if (x - 1 >= 0 && y + 1 < Vertical && !_mines[x - 1, y + 1].bomb && !_mines[x - 1, y + 1].open) checkForEmpty(_mines[x - 1, y + 1]);
                    if (x - 1 >= 0 && !_mines[x - 1, y].bomb && !_mines[x - 1, y].open) checkForEmpty(_mines[x - 1, y]);
                }
            }
        }
    }

        public class MineEventArgs : EventArgs {
            public MineEventArgs(MineInfo _tMineInfo) {
                tMineInfo = _tMineInfo;
            }

            public MineInfo tMineInfo;
        }
    
}
