using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TikTakToe
{
    class TikTakToeModel
    {
        List<string> _area;
        bool _isCross;
        int _count;

        public TikTakToeModel()
        {
            _count = 0;
            _isCross = true;
            _area = new List<string>()
            {
                " ",
                " ",
                " ",
                " ",
                " ",
                " ",
                " ",
                " ",
                " "
            };
        }

        public string PlayTurn(int index)
        {
            if (_area[index] == " ")
            {
                if (_isCross)
                    _area[index] = "X";
                else
                    _area[index] = "O";
                _isCross = !_isCross;
                _count++;
            }

            return _area[index];
        }

        public string CheckWinner()
        {
            if (IsWinner())
                if (_isCross)
                    return "Победили Нолики";
                else
                    return "Победили Крестики";
                else if (_count >= 9)
                    return "Ничья";
            return null;
        }

        private bool IsWinner()
        {
            if (_area[0] == _area[1] && _area[1] == _area[2] && _area[2] != " ") return true;
            if (_area[3] == _area[4] && _area[4] == _area[5] && _area[5] != " ") return true;
            if (_area[6] == _area[7] && _area[7] == _area[8] && _area[8] != " ") return true;

            if (_area[0] == _area[3] && _area[3] == _area[6] && _area[6] != " ") return true;
            if (_area[1] == _area[4] && _area[4] == _area[7] && _area[7] != " ") return true;
            if (_area[2] == _area[5] && _area[5] == _area[8] && _area[8] != " ") return true;

            if (_area[0] == _area[4] && _area[4] == _area[8] && _area[8] != " ") return true;
            if (_area[2] == _area[4] && _area[4] == _area[6] && _area[6] != " ") return true;

            return false;
        }
    }
}
