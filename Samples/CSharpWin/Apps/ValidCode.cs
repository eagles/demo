﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace CSharpWin.Apps
{
    public class ValidCode
    {
        #region Private Fields

        private const double PI = 3.1415926535897932384626433832795;
        private const double PI2 = 6.283185307179586476925286766559;
        //private readonly int _wordsLen = 4;
        private int _len;
        private CodeType _codeType;
        private readonly Single _codeDistance = (float)15.0;
        private readonly Single _height = (float)24.0;
        private string _checkCode;

        #endregion

        #region Public Property

        public string CheckCode
        {
            get
            {
                return _checkCode;
            }
        }
        #endregion

        #region Constructors

        /// <summary>
        /// public constructors
        /// </summary>
        /// <param name="len"> 验证码长度 </param>
        /// <param name="ctype"> 验证码类型：字母、数字、字母+ 数字 </param>
        public ValidCode(int len, CodeType ctype)
        {
            this._len = len;
            this._codeType = ctype;
        }

        #endregion

        #region Public Field

        /// <summary>
        /// Valid Code Type.  Words, Numbers, Characters, Alphas
        /// </summary>
        public enum CodeType { Words, Numbers, Characters, Alphas }

        #endregion

        #region Private Methods

        /// <summary>
        /// Generate Numberic Code
        /// </summary>
        /// <returns></returns>
        private string GenerateNumbers()
        {
            string strOut = "";
            Random random = new Random();
            for (int i = 0; i < _len; i++)
            {
                string num = Convert.ToString(random.Next(10000) % 10);
                strOut += num;
            }
            return strOut.Trim();
        }

        /// <summary>
        /// Generate Character Code
        /// </summary>
        /// <returns></returns>
        private string GenerateCharacters()
        {
            string strOut = "";
            Random random = new Random();
            for (int i = 0; i < _len; i++)
            {
                string num = Convert.ToString((char)(65 + random.Next(10000) % 26));
                strOut += num;
            }
            return strOut.Trim();
        }
        
        /// <summary>
        /// Generate Alphabetical Code
        /// </summary>
        /// <returns></returns>
        private string GenerateAlphas()
        {
            string strOut = "";
            string num = "";
            Random random = new Random();
            for (int i = 0; i < _len; i++)
            {
                if (random.Next(500) % 2 == 0)
                {
                    num = Convert.ToString(random.Next(10000) % 10);
                }
                else
                {
                    num = Convert.ToString((char)(65 + random.Next(10000) % 26));
                }
                strOut += num;
            }
            return strOut.Trim();
        }

        private Bitmap TwistImage(Bitmap srcBmp, bool bXDir, double dMultValue, double dPhase)
        {
            Bitmap destBmp = new Bitmap(srcBmp.Width, srcBmp.Height);

            // 将位图背景填充为白色
            Graphics graph = Graphics.FromImage(destBmp);
            graph.FillRectangle(new SolidBrush(Color.White), 0, 0, destBmp.Width, destBmp.Height);
            graph.Dispose();

            double dBaseAxisLen = bXDir ? (double)destBmp.Height : (double)destBmp.Width;

            for (int i = 0; i < destBmp.Width; i++)
            {
                for (int j = 0; j < destBmp.Height; j++)
                {
                    double dx = 0;
                    dx = bXDir ? (PI2 * (double)j) / dBaseAxisLen : (PI2 * (double)i) / dBaseAxisLen;
                    dx += dPhase;
                    double dy = Math.Sin(dx);

                    // 取得当前点的颜色
                    int nOldX = 0, nOldY = 0;
                    nOldX = bXDir ? i + (int)(dy * dMultValue) : i;
                    nOldY = bXDir ? j : j + (int)(dy * dMultValue);

                    System.Drawing.Color color = srcBmp.GetPixel(i, j);
                    if (nOldX >= 0 && nOldX < destBmp.Width
                     && nOldY >= 0 && nOldY < destBmp.Height)
                    {
                        destBmp.SetPixel(nOldX, nOldY, color);
                    }
                }
            }

            return destBmp;
        }
        #endregion

        #region Public Methods

        /// <summary>
        /// Create Check Code Image
        /// </summary>
        /// <returns></returns>
        public Stream CreateCheckCodeImage()
        {
            string checkCode;
            switch (_codeType)
            {
                case CodeType.Alphas:
                    checkCode = GenerateAlphas();
                    break;
                case CodeType.Numbers:
                    checkCode = GenerateNumbers();
                    break;
                case CodeType.Characters:
                    checkCode = GenerateCharacters();
                    break;
                default:
                    checkCode = GenerateAlphas();
                    break;
            }
            this._checkCode = checkCode;
            MemoryStream ms = null;
            //
            if (checkCode == null || checkCode.Trim() == String.Empty)
                return null;
            Bitmap image = new Bitmap((int)Math.Ceiling((checkCode.Length * _codeDistance)), (int)_height);
            Graphics g = Graphics.FromImage(image);
            try
            {
                Random random = new Random();
                g.Clear(Color.White);
                // 画图片的背景噪音线
                for (int i = 0; i < 18; i++)
                {
                    int x1 = random.Next(image.Width);
                    int x2 = random.Next(image.Width);
                    int y1 = random.Next(image.Height);
                    int y2 = random.Next(image.Height);
                    g.DrawLine(new Pen(Color.FromArgb(random.Next()), 1), x1, y1, x2, y2);
                }
                Font font = new Font("Times New Roman", 14, FontStyle.Bold);
                LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(0, 0, image.Width, image.Height), Color.Blue, Color.DarkRed, 1.2f, true);
                if (_codeType != CodeType.Words)
                {
                    for (int i = 0; i < checkCode.Length; i++)
                    {
                        g.DrawString(checkCode.Substring(i, 1), font, brush, 2 + i * _codeDistance, 1);
                    }
                }
                else
                {
                    g.DrawString(checkCode, font, brush, 2, 2);
                }
                // 画图片的前景噪音点
                for (int i = 0; i < 150; i++)
                {
                    int x = random.Next(image.Width);
                    int y = random.Next(image.Height);
                    image.SetPixel(x, y, Color.FromArgb(random.Next()));
                }
                // 画图片的波形滤镜效果
                if (_codeType != CodeType.Words)
                {
                    image = TwistImage(image, true, 3, 1);
                }
                // 画图片的边框线
                g.DrawRectangle(new Pen(Color.Silver), 0, 0, image.Width - 1, image.Height - 1);

                ms = new MemoryStream();
                image.Save(ms, ImageFormat.Gif);
            }
            finally
            {
                g.Dispose();
                image.Dispose();
            }
            return ms;
        }
        #endregion
    }
}
