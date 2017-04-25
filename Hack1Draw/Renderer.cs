using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
using System.Drawing.Imaging;

namespace PerfectPidgeon.Draw
{
    public class Renderer
    {
        private bool _InDraw;
        private bool _GLLoaded;
        private int _TexturePointer;
        private ArtData _ArtData;
        private GameData _Data;
        private Controls _Controls;
        private GLControl _GLD;
        public bool GLLoaded
        {
            get
            {
                return _GLLoaded;
            }

            set
            {
                _GLLoaded = value;
            }
        }
        public Renderer(GLControl GLD, GameData Data, ArtData AData, Controls Controls_)
        {
            this._InDraw = false;
            this._Data = Data;
            this._ArtData = AData;
            this._GLD = GLD;
            this._Controls = Controls_;
        }
        private void DrawImage(int X, int Y, int XSize, int YSize, Bitmap ToDraw)
        {
            if (ToDraw == null) return;
            SetTexture(ref ToDraw);
            GL.Begin(BeginMode.Polygon);
            GL.TexCoord2(0f, 0f); GL.Vertex2(X, Y);
            GL.TexCoord2(0f, 1f); GL.Vertex2(X, Y + YSize);
            GL.TexCoord2(1f, 1f); GL.Vertex2(X + XSize, Y + YSize);
            GL.TexCoord2(1f, 0f); GL.Vertex2(X + XSize, Y);
            GL.End();
        }
        private void DrawImageNTexture(int X, int Y, int XSize, int YSize)
        {
            GL.Begin(BeginMode.Polygon);
            GL.TexCoord2(0f, 0f); GL.Vertex2(X, Y);
            GL.TexCoord2(0f, 1f); GL.Vertex2(X, Y + YSize);
            GL.TexCoord2(1f, 1f); GL.Vertex2(X + XSize, Y + YSize);
            GL.TexCoord2(1f, 0f); GL.Vertex2(X + XSize, Y);
            GL.End();
        }
        private void SetTexture(ref Bitmap NewTexture)
        {
            GL.DeleteTextures(1, ref this._TexturePointer);
            GL.GenTextures(1, out this._TexturePointer);
            GL.BindTexture(TextureTarget.Texture2D,  this._TexturePointer);
            BitmapData data = NewTexture.LockBits(new System.Drawing.Rectangle(0, 0, NewTexture.Width, NewTexture.Height),
                ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, data.Width, data.Height, 0,
                OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);
            NewTexture.UnlockBits(data);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
            GL.BindTexture(TextureTarget.Texture2D, this._TexturePointer);
        }
        public void Init()
        {
            this._GLD.MakeCurrent();
            this.GLLoaded = true;
            GL.ClearColor(Color.LightGray);
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);
        }
        public void Transform()
        {
            GL.Viewport(0, 0, _GLD.Width, _GLD.Height);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(0, _GLD.Width, _GLD.Height, 0, -1, 1);
        }
        public void Draw()
        {
            if (_InDraw) return;
            _InDraw = true;

            this.Transform();
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.Enable(EnableCap.Texture2D);

            if (this._ArtData.BackType == 0)
            {
                DrawImage(0, 0, this._ArtData.Back.Width, this._ArtData.Back.Height, this._ArtData.Back);
            }
            else if (this._ArtData.BackType == 1)
            {
                int XOffset = this._Data.Players[this._Data.CurrentPlayer].Location.X;
                int YOffset = this._Data.Players[this._Data.CurrentPlayer].Location.Y;
                XOffset %= _GLD.Width;
                YOffset %= _GLD.Height;
                

                DrawImage(-XOffset, -YOffset, _GLD.Width, _GLD.Height, this._ArtData.Back);
                DrawImageNTexture(-XOffset + _GLD.Width,    -YOffset,               _GLD.Width, _GLD.Height);
                DrawImageNTexture(-XOffset - _GLD.Width,    -YOffset,               _GLD.Width, _GLD.Height);
                DrawImageNTexture(-XOffset,                 -YOffset - _GLD.Height, _GLD.Width, _GLD.Height);
                DrawImageNTexture(-XOffset + _GLD.Width,    -YOffset - _GLD.Height, _GLD.Width, _GLD.Height);
                DrawImageNTexture(-XOffset - _GLD.Width,    -YOffset - _GLD.Height, _GLD.Width, _GLD.Height);
                DrawImageNTexture(-XOffset,                 -YOffset + _GLD.Height, _GLD.Width, _GLD.Height);
                DrawImageNTexture(-XOffset + _GLD.Width,    -YOffset + _GLD.Height, _GLD.Width, _GLD.Height);
                DrawImageNTexture(-XOffset - _GLD.Width,    -YOffset + _GLD.Height, _GLD.Width, _GLD.Height);
            }
            else if (this._ArtData.BackType == 2)
            {
                int XOffset = this._Data.Players[this._Data.CurrentPlayer].Location.X;
                int YOffset = this._Data.Players[this._Data.CurrentPlayer].Location.Y;
                XOffset %= _ArtData.Back.Width;
                YOffset %= _ArtData.Back.Height;

                DrawImage(-XOffset, -YOffset, _ArtData.Back.Width, _ArtData.Back.Height, _ArtData.Back);
                DrawImageNTexture(-XOffset + _ArtData.Back.Width, -YOffset, _ArtData.Back.Width, _ArtData.Back.Height);
                DrawImageNTexture(-XOffset - _ArtData.Back.Width, -YOffset, _ArtData.Back.Width, _ArtData.Back.Height);
                DrawImageNTexture(-XOffset, -YOffset - _ArtData.Back.Height, _ArtData.Back.Width, _ArtData.Back.Height);
                DrawImageNTexture(-XOffset + _ArtData.Back.Width, -YOffset - _ArtData.Back.Height, _ArtData.Back.Width, _ArtData.Back.Height);
                DrawImageNTexture(-XOffset - _ArtData.Back.Width, -YOffset - _ArtData.Back.Height, _ArtData.Back.Width, _ArtData.Back.Height);
                DrawImageNTexture(-XOffset, -YOffset + _ArtData.Back.Height, _ArtData.Back.Width, _ArtData.Back.Height);
                DrawImageNTexture(-XOffset + _ArtData.Back.Width, -YOffset + _ArtData.Back.Height, _ArtData.Back.Width, _ArtData.Back.Height);
                DrawImageNTexture(-XOffset - _ArtData.Back.Width, -YOffset + _ArtData.Back.Height, _ArtData.Back.Width, _ArtData.Back.Height);
            }

            /*if (this._ArtData.BackType == 2)
            {
                int XOffset = this._Data.Players[this._Data.CurrentPlayer].Location.X;
                int YOffset = this._Data.Players[this._Data.CurrentPlayer].Location.Y;
                XOffset %= _ArtData.Clouds.Width;
                YOffset %= _ArtData.Clouds.Height;

                DrawImage(-XOffset, -YOffset, _ArtData.Clouds.Width, _ArtData.Clouds.Height, _ArtData.Clouds);
                DrawImageNTexture(-XOffset + _ArtData.Clouds.Width, -YOffset, _ArtData.Clouds.Width, _ArtData.Clouds.Height);
                DrawImageNTexture(-XOffset - _ArtData.Clouds.Width, -YOffset, _ArtData.Clouds.Width, _ArtData.Clouds.Height);
                DrawImageNTexture(-XOffset, -YOffset - _ArtData.Clouds.Height, _ArtData.Clouds.Width, _ArtData.Clouds.Height);
                DrawImageNTexture(-XOffset + _ArtData.Clouds.Width, -YOffset - _ArtData.Clouds.Height, _ArtData.Clouds.Width, _ArtData.Clouds.Height);
                DrawImageNTexture(-XOffset - _ArtData.Clouds.Width, -YOffset - _ArtData.Clouds.Height, _ArtData.Clouds.Width, _ArtData.Clouds.Height);
                DrawImageNTexture(-XOffset, -YOffset + _ArtData.Clouds.Height, _ArtData.Clouds.Width, _ArtData.Clouds.Height);
                DrawImageNTexture(-XOffset + _ArtData.Clouds.Width, -YOffset + _ArtData.Clouds.Height, _ArtData.Clouds.Width, _ArtData.Clouds.Height);
                DrawImageNTexture(-XOffset - _ArtData.Clouds.Width, -YOffset + _ArtData.Clouds.Height, _ArtData.Clouds.Width, _ArtData.Clouds.Height);
            }*/

            try
            {
                GL.Color3(Color.Black);
                for (int i = 0; i < this._Data.Projectiles.Count; i++)
                {
                    if (this._Data.Projectiles[i].Location.X - this._Data.Players[this._Data.CurrentPlayer].Location.X < _GLD.Width * 1.5)
                    {
                        if (this._Data.Projectiles[i].Location.Y - this._Data.Players[this._Data.CurrentPlayer].Location.Y < _GLD.Height * 1.5)
                        {
                            GL.Translate(this._Data.Projectiles[i].Location.X - this._Data.Players[this._Data.CurrentPlayer].Location.X, this._Data.Projectiles[i].Location.Y - this._Data.Players[this._Data.CurrentPlayer].Location.Y, 0);
                            GL.Translate(_GLD.Width / 2, _GLD.Height / 2, 0);
                            GL.Rotate(-this._Data.Projectiles[i].Facing + 180, 0, 0, -1);
                            if (this._Data.Projectiles[i].ArtIndex == 0)
                            {
                                GL.Color3(Color.Black);
                                DrawImage((int)(-this._ArtData.Bullets[this._Data.Projectiles[i].ArtIndex].Images[0].Width / 6), (int)(-this._ArtData.Bullets[this._Data.Projectiles[i].ArtIndex].Images[0].Height / 6), this._ArtData.Bullets[this._Data.Projectiles[i].ArtIndex].Images[0].Width / 3, this._ArtData.Bullets[this._Data.Projectiles[i].ArtIndex].Images[0].Height / 3, this._ArtData.Bullets[this._Data.Projectiles[i].ArtIndex].Images[0]);
                            }
                            else if (this._Data.Projectiles[i].ArtIndex == 1)
                            {
                                GL.Color3(this._ArtData.Environment);
                                DrawImage((int)(-this._ArtData.Bullets[this._Data.Projectiles[i].ArtIndex].Images[0].Width / 4), (int)(-this._ArtData.Bullets[this._Data.Projectiles[i].ArtIndex].Images[0].Height / 4), this._ArtData.Bullets[this._Data.Projectiles[i].ArtIndex].Images[0].Width / 2, this._ArtData.Bullets[this._Data.Projectiles[i].ArtIndex].Images[0].Height / 2, this._ArtData.Bullets[this._Data.Projectiles[i].ArtIndex].Images[0]);
                            }
                            else if (this._Data.Projectiles[i].ArtIndex == 2)
                            {
                                GL.Color3(this._ArtData.Environment);
                                DrawImage((int)(-this._ArtData.Bullets[this._Data.Projectiles[i].ArtIndex].Images[0].Width / 2), (int)(-this._ArtData.Bullets[this._Data.Projectiles[i].ArtIndex].Images[0].Height / 2), this._ArtData.Bullets[this._Data.Projectiles[i].ArtIndex].Images[0].Width, this._ArtData.Bullets[this._Data.Projectiles[i].ArtIndex].Images[0].Height, this._ArtData.Bullets[this._Data.Projectiles[i].ArtIndex].Images[0]);
                            }
                            else if (this._Data.Projectiles[i].ArtIndex == 3)
                            {
                                GL.Color3(this._ArtData.Environment);
                                GL.Rotate(-this._Data.Projectiles[i].ImageIndex, 0, 0, -1);
                                DrawImage((int)(-this._ArtData.Bullets[this._Data.Projectiles[i].ArtIndex].Images[0].Width / 4), (int)(-this._ArtData.Bullets[this._Data.Projectiles[i].ArtIndex].Images[0].Height / 4), this._ArtData.Bullets[this._Data.Projectiles[i].ArtIndex].Images[0].Width / 2, this._ArtData.Bullets[this._Data.Projectiles[i].ArtIndex].Images[0].Height / 2, this._ArtData.Bullets[this._Data.Projectiles[i].ArtIndex].Images[0]);
                            }
                            else if (this._Data.Projectiles[i].ArtIndex == 10)
                            {
                                GL.Color3(this._ArtData.Environment);
                                //GL.Color3(Color.FromArgb(100,100,100));
                                DrawImage((int)(-this._ArtData.Bullets[this._Data.Projectiles[i].ArtIndex].Images[0].Width / 4), (int)(-this._ArtData.Bullets[this._Data.Projectiles[i].ArtIndex].Images[0].Height / 4), (int)(this._ArtData.Bullets[this._Data.Projectiles[i].ArtIndex].Images[0].Width * 1) / 2, (int)(this._ArtData.Bullets[this._Data.Projectiles[i].ArtIndex].Images[0].Height * 1) / 2, this._ArtData.Bullets[this._Data.Projectiles[i].ArtIndex].Images[0]);
                            }
                            else if (this._Data.Projectiles[i].ArtIndex == 11)
                            {
                                GL.Color3(this._ArtData.Environment);
                                GL.Color3(Color.FromArgb(100, 100, 100));
                                DrawImage((int)(-this._ArtData.Bullets[this._Data.Projectiles[i].ArtIndex].Images[0].Width / 4), (int)(-this._ArtData.Bullets[this._Data.Projectiles[i].ArtIndex].Images[0].Height / 4), (int)(this._ArtData.Bullets[this._Data.Projectiles[i].ArtIndex].Images[0].Width * 1) / 2, (int)(this._ArtData.Bullets[this._Data.Projectiles[i].ArtIndex].Images[0].Height * 1) / 2, this._ArtData.Bullets[this._Data.Projectiles[i].ArtIndex].Images[0]);
                            }
                            else if (this._Data.Projectiles[i].ArtIndex == 12)
                            {
                                GL.Color3(this._ArtData.Environment);
                                //GL.Color3(Color.FromArgb(100, 100, 100));
                                DrawImage((int)(-this._ArtData.Bullets[this._Data.Projectiles[i].ArtIndex].Images[0].Width / 4), (int)(-this._ArtData.Bullets[this._Data.Projectiles[i].ArtIndex].Images[0].Height / 4), (int)(this._ArtData.Bullets[this._Data.Projectiles[i].ArtIndex].Images[0].Width * 1) / 2, (int)(this._ArtData.Bullets[this._Data.Projectiles[i].ArtIndex].Images[0].Height * 1) / 2, this._ArtData.Bullets[this._Data.Projectiles[i].ArtIndex].Images[0]);
                            }
                            else if (this._Data.Projectiles[i].ArtIndex == 13)
                            {
                                GL.Color3(this._ArtData.Environment);
                                //GL.Color3(Color.FromArgb(100, 100, 100));
                                DrawImage((int)(-this._ArtData.Bullets[this._Data.Projectiles[i].ArtIndex].Images[0].Width / 4), (int)(-this._ArtData.Bullets[this._Data.Projectiles[i].ArtIndex].Images[0].Height / 4), (int)(this._ArtData.Bullets[this._Data.Projectiles[i].ArtIndex].Images[0].Width * 1) / 2, (int)(this._ArtData.Bullets[this._Data.Projectiles[i].ArtIndex].Images[0].Height * 1) / 2, this._ArtData.Bullets[this._Data.Projectiles[i].ArtIndex].Images[0]);
                            }
                            else if (this._Data.Projectiles[i].ArtIndex == 14)
                            {
                                GL.Color3(this._ArtData.Environment);
                                //GL.Color3(Color.FromArgb(100, 100, 100));
                                DrawImage((int)(-this._ArtData.Bullets[this._Data.Projectiles[i].ArtIndex].Images[0].Width / 4), (int)(-this._ArtData.Bullets[this._Data.Projectiles[i].ArtIndex].Images[0].Height / 4), (int)(this._ArtData.Bullets[this._Data.Projectiles[i].ArtIndex].Images[0].Width * 1) / 2, (int)(this._ArtData.Bullets[this._Data.Projectiles[i].ArtIndex].Images[0].Height * 1) / 2, this._ArtData.Bullets[this._Data.Projectiles[i].ArtIndex].Images[0]);
                            }
                            else if (this._Data.Projectiles[i].ArtIndex == 16)
                            {
                                GL.Color3(this._ArtData.Environment);
                                //GL.Color3(Color.FromArgb(100, 100, 100));
                                DrawImage((int)(-this._ArtData.Bullets[this._Data.Projectiles[i].ArtIndex].Images[0].Width / 4), (int)(-this._ArtData.Bullets[this._Data.Projectiles[i].ArtIndex].Images[0].Height / 4), (int)(this._ArtData.Bullets[this._Data.Projectiles[i].ArtIndex].Images[0].Width * 1) / 2, (int)(this._ArtData.Bullets[this._Data.Projectiles[i].ArtIndex].Images[0].Height * 1) / 2, this._ArtData.Bullets[this._Data.Projectiles[i].ArtIndex].Images[0]);
                            }
                            GL.LoadIdentity();
                        }
                    }
                }
            }
            catch { };

            try
            {
                GL.Color3(this._ArtData.Environment);
                for (int i = 0; i < this._Data.Effects.Count; i++)
                {
                    if (this._Data.Effects[i].Location.X - this._Data.Players[this._Data.CurrentPlayer].Location.X < _GLD.Width * 1.5)
                    {
                        if (this._Data.Effects[i].Location.Y - this._Data.Players[this._Data.CurrentPlayer].Location.Y < _GLD.Height * 1.5)
                        {
                            GL.Translate(this._Data.Effects[i].Location.X - this._Data.Players[this._Data.CurrentPlayer].Location.X, this._Data.Effects[i].Location.Y - this._Data.Players[this._Data.CurrentPlayer].Location.Y, 0);
                            GL.Translate(_GLD.Width / 2, _GLD.Height / 2, 0);

                            if (this._Data.Effects[i].ArtIndex == 0)
                            {
                                DrawImage(-this._ArtData.EffectArt[this._Data.Effects[i].ArtIndex].Width / 8, -this._ArtData.EffectArt[this._Data.Effects[i].ArtIndex].Height / 8, this._ArtData.EffectArt[this._Data.Effects[i].ArtIndex].Width / 4, this._ArtData.EffectArt[this._Data.Effects[i].ArtIndex].Height / 4, this._ArtData.EffectArt[this._Data.Effects[i].ArtIndex]);
                            }
                            else if (this._Data.Effects[i].ArtIndex == 1)
                            {
                                GL.Color3(this._ArtData.Environment);
                                DrawImage(-this._ArtData.EffectArt[this._Data.Effects[i].ArtIndex].Width / 4, -this._ArtData.EffectArt[this._Data.Effects[i].ArtIndex].Height / 4, this._ArtData.EffectArt[this._Data.Effects[i].ArtIndex].Width / 2, this._ArtData.EffectArt[this._Data.Effects[i].ArtIndex].Height / 2, this._ArtData.EffectArt[this._Data.Effects[i].ArtIndex]);
                            }

                            GL.LoadIdentity();
                        }
                    }
                }
            }
            catch { }

            
            {
                GL.Color3(this._ArtData.Environment);
                for (int i = 0; i < this._Data.NPCs.Count; i++)
                {
                    if (this._Data.NPCs[i].Location.X - this._Data.Players[this._Data.CurrentPlayer].Location.X < _GLD.Width * 1.5)
                    {
                        if (this._Data.NPCs[i].Location.Y - this._Data.Players[this._Data.CurrentPlayer].Location.Y < _GLD.Height * 1.5)
                        {
                            GL.Translate(this._Data.NPCs[i].Location.X - this._Data.Players[this._Data.CurrentPlayer].Location.X, this._Data.NPCs[i].Location.Y - this._Data.Players[this._Data.CurrentPlayer].Location.Y, 0);
                            GL.Translate(_GLD.Width / 2, _GLD.Height / 2, 0);
                            GL.Rotate(this._Data.NPCs[i].Facing, 0, 0, -1);
                            DrawImage((int)(-this._ArtData.SpriteSets[this._Data.NPCs[i].ArtIndex].Images[this._Data.NPCs[i].ImageIndex].Width * this._Data.NPCs[i].Size / 4), (int)(-this._ArtData.SpriteSets[this._Data.NPCs[i].ArtIndex].Images[this._Data.NPCs[i].ImageIndex].Height * this._Data.NPCs[i].Size / 4), (int)(this._ArtData.SpriteSets[this._Data.NPCs[i].ArtIndex].Images[this._Data.NPCs[i].ImageIndex].Width * this._Data.NPCs[i].Size) / 2, (int)(this._ArtData.SpriteSets[this._Data.NPCs[i].ArtIndex].Images[this._Data.NPCs[i].ImageIndex].Height * this._Data.NPCs[i].Size) / 2, this._ArtData.SpriteSets[this._Data.NPCs[i].ArtIndex].Images[this._Data.NPCs[i].ImageIndex]);
                            GL.LoadIdentity();
                        }
                    }
                }
            }
            

            GL.Color3(this._ArtData.Environment);
            if (this._Data.PowerUps != null)
                for (int i = 0; i < this._Data.PowerUps.Count; i++)
                {
                    if (this._Data.PowerUps[i].Location.X - this._Data.Players[this._Data.CurrentPlayer].Location.X < _GLD.Width * 1.5)
                    {
                        if (this._Data.PowerUps[i].Location.Y - this._Data.Players[this._Data.CurrentPlayer].Location.Y < _GLD.Height * 1.5)
                        {
                            GL.Translate(this._Data.PowerUps[i].Location.X - this._Data.Players[this._Data.CurrentPlayer].Location.X, this._Data.PowerUps[i].Location.Y - this._Data.Players[this._Data.CurrentPlayer].Location.Y, 0);
                            GL.Translate(_GLD.Width / 2, _GLD.Height / 2, 0);
                            GL.Rotate(this._Data.PowerUps[i].Facing, 0, 0, -1);
                            DrawImage((int)(-this._ArtData.PowerUpArt[this._Data.PowerUps[i].ArtIndex].Width / 2), (int)(-this._ArtData.PowerUpArt[this._Data.PowerUps[i].ArtIndex].Height / 2), this._ArtData.PowerUpArt[this._Data.PowerUps[i].ArtIndex].Width, this._ArtData.PowerUpArt[this._Data.PowerUps[i].ArtIndex].Height, this._ArtData.PowerUpArt[this._Data.PowerUps[i].ArtIndex]);
                            GL.LoadIdentity();
                        }
                    }
                }

            DrawImage(this._Controls.MouseLoc.X - 50, this._Controls.MouseLoc.Y - 50, 100, 100, this._ArtData.Aim);

            GL.LoadIdentity();
            GL.Color3(this._ArtData.Environment);
            GL.Translate(_GLD.Width / 2, _GLD.Height / 2, 0);
            GL.Rotate(this._Controls.MouseAngle + this._Data.Players[0].AngleOffsetIndex, 0, 0, -1);
            DrawImage(-this._ArtData.SpriteSets[0].Images[this._Data.Players[0].ImageIndex].Width / 4, -this._ArtData.SpriteSets[0].Images[this._Data.Players[0].ImageIndex].Height / 4, this._ArtData.SpriteSets[0].Images[this._Data.Players[0].ImageIndex].Width / 2, this._ArtData.SpriteSets[0].Images[this._Data.Players[0].ImageIndex].Height / 2, this._ArtData.SpriteSets[0].Images[this._Data.Players[0].ImageIndex]);
            GL.Rotate(-this._Data.Players[0].Other, 0, 0, -1);
            DrawImage(-this._ArtData.SpriteSets[1].Images[4].Width / 4, -this._ArtData.SpriteSets[1].Images[4].Height / 4, this._ArtData.SpriteSets[1].Images[4].Width / 2, this._ArtData.SpriteSets[1].Images[4].Height / 2, this._ArtData.SpriteSets[1].Images[4]);
            DrawImage(-this._ArtData.SpriteSets[1].Images[this._Data.Players[0].ArtIndex].Width / 4, -this._ArtData.SpriteSets[1].Images[this._Data.Players[0].ArtIndex].Height / 4, this._ArtData.SpriteSets[1].Images[this._Data.Players[0].ArtIndex].Width / 2, this._ArtData.SpriteSets[1].Images[this._Data.Players[0].ArtIndex].Height / 2, this._ArtData.SpriteSets[1].Images[this._Data.Players[0].ArtIndex]);
            GL.LoadIdentity();

            GL.Disable(EnableCap.Texture2D);
            _GLD.SwapBuffers();
            _GLD.Invalidate();
            _InDraw = false;
        }
    }
}
