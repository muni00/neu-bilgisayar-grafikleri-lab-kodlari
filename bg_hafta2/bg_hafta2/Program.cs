using System;
using OpenTK;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;
using System.Windows.Input;

namespace OpenTK_ConsoleApp
{
    public class Game : GameWindow//GameWindow, basit bir window sınıfıdır.
    {

        public Game() : base(GameWindowSettings.Default, NativeWindowSettings.Default)
        {//GameWindow sınıfının base constructor metodunu override ediyoruz.
            //1.parametre gamewindows ayarlamaları ikinci parametre ise windows pencere ayarlamaları
            this.CenterWindow(new Vector2i(1000, 500));//windowun boyutunu değiştirmek için eklenir.
        }
        //Gamewindowa işlev eklemek için bazı fonskiyonların override edilmesi gerekir.
        //Onupdateframe bunlardan biri
        protected override void OnUpdateFrame(FrameEventArgs args)
        {
            base.OnUpdateFrame(args);
        }

        protected override void OnRenderFrame(FrameEventArgs args)
        {
            GL.ClearColor(new Color4<Rgba>(0.3f, 0.4f, 0.5f, 1f));//ekranı temizlemizi yani boyamamızı sağlıyor.
            GL.Clear(ClearBufferMask.ColorBufferBit);//rendering işleminde bir hata olmaması için clear ile buffera temizliyoruz.
            //colorbufferbit temel temizleme araçlarından bir tanesidir.

            this.Context.SwapBuffers();//Bu işlem de yine rendering işlemlerinde hata olmaması için kullanılan bir fonksiyon
            //Hemen hemen her modern OpenGL bağlamı, "çift arabellekli" olarak bilinir.
            //Çift arabelleğe alma, OpenGL'nin çizim yaptığı iki alan olduğu anlamına gelir. Özünde: Bir alan görüntülenirken diğeri oluşturulur. Ardından SwapBuffers'ı aradığınızda ikisi tersine çevrilir.
            base.OnRenderFrame(args);
        }

        protected override void OnLoad()
        {

        }
    }
    ﻿
namespace OpenTK_ConsoleApp
    {
        class Program
        {
            static void Main(string[] args)
            {
                //GameWindow sınıfından bir nesne üretilip, pencerenin ekranda gözükmesi için run metodu çalıştırılır.
                using (Game game = new Game())
                {
                    game.Run();
                }
            }
        }
    }
}