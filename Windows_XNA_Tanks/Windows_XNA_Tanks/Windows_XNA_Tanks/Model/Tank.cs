using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Windows_XNA_Tanks.Model
{
    class Tank : Entity
    {
        private Point _startPoint;
        // Constructor

        public Tank(ContentManager content, Point startPoint)
        {
            Texture = content.Load<Texture2D>("tiles/tank");
            _startPoint = startPoint;
            Point = _startPoint;
        }

        #region Methods

        public void Update()
        {

        }
        #endregion Methods

        public Point StartPoint
        {
            get { return _startPoint; }
            set { _startPoint = value; }
        }
    }
}
