using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infy2
{
    /// <summary>
    /// ���C�t�Q�[���̃Z���̍��W���Ǘ����邽�߂̃N���X�ł��B
    /// </summary>
    struct CellOfLifeGame
    {
        private int x, y;

        /// <summary>�Z����x���̒l��\���܂��B</summary>
        public int X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }

        /// <summary>�Z����y���̒l��\���܂��B</summary>
        public int Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }

        /// <summary>
        /// LifeGame�̃Z���̍��W���i�[���邽�߂̃R���X�g���N�^�ł��B
        /// </summary>
        /// <param name="x">�Z����x���̒l��\���܂��B</param> 
        /// <param name="y">�Z����y���̒l��\���܂��B</param>       
        public CellOfLifeGame(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// ���W�̐�Βl���v�Z���A���_����̋������v�Z���܂��B
        /// </summary>
        public double Abs() { return Math.Sqrt(x * x + y * y); }
    }
}