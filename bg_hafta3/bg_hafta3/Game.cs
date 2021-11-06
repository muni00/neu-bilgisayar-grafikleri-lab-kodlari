using OpenTK.Windowing.Desktop;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;

public class Game : GameWindow
{
    private int vertexBufferHandle;
    private int vertexArrayHandle;
    private int shaderProgramHandle;
    public Game() : base(GameWindowSettings.Default, NativeWindowSettings.Default)
    {
        this.CenterWindow(new Vector2i(500, 600));
        
    }
    protected override void OnUpdateFrame(FrameEventArgs args)
    {
        base.OnUpdateFrame(args);
    }
    protected override void OnRenderFrame(FrameEventArgs args)
    {
        GL.Clear(ClearBufferMask.ColorBufferBit);

        GL.UseProgram((OpenTK.Graphics.ProgramHandle)shaderProgramHandle);
        GL.BindVertexArray((OpenTK.Graphics.VertexArrayHandle)vertexArrayHandle);

        GL.DrawArrays(PrimitiveType.Triangles, 0, 3);

        this.Context.SwapBuffers();
        base.OnRenderFrame(args);
    }
    protected override void OnLoad()
    {
        GL.ClearColor(0.9f, 0.2f, 0.8f, 1f);

        float[] vertices = new float[]
        {
            0.0f,0.5f,0.0f,
            0.5f,-0.5f,0.0f,
            -0.5f,-0.5f,0.0f
        };


        this.vertexBufferHandle = (int)GL.GenBuffer();
        GL.BindBuffer(BufferTargetARB.ArrayBuffer, (OpenTK.Graphics.BufferHandle)this.vertexBufferHandle);
        GL.BufferData(BufferTargetARB.ArrayBuffer, vertices.Length * sizeof(float),vertices ,BufferUsageARB.StaticDraw);
        GL.BindBuffer(BufferTargetARB.ArrayBuffer, (OpenTK.Graphics.BufferHandle)0);

        this.vertexArrayHandle = (int)GL.GenVertexArray();
        GL.BindVertexArray((OpenTK.Graphics.VertexArrayHandle)vertexArrayHandle);
        GL.BindBuffer(BufferTargetARB.ArrayBuffer, (OpenTK.Graphics.BufferHandle)vertexBufferHandle);
        GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
        GL.EnableVertexAttribArray(0);
        GL.BindVertexArray((OpenTK.Graphics.VertexArrayHandle)0);

        string vertexShaderCode =
            @"
             #version 330 core
             layout (location = 0) in vec3 aPosition;
             void main()
                {
                      gl_Position = vec4(aPosition,1f);
              }
             ";
        string pixelShaderCode =
            @"
             #version 330 core
             out vec4 pixelColor;

             void main()
            {
                  pixelColor = vec4(0.8f, 0.8f, 0.1f, 1f);
            }
             ";
        int vertexSharedHandle =(int) GL.CreateShader(ShaderType.VertexShader);
        GL.ShaderSource((OpenTK.Graphics.ShaderHandle)vertexSharedHandle, vertexShaderCode);
        GL.CompileShader((OpenTK.Graphics.ShaderHandle)vertexSharedHandle);

        int pixelSharedHandle = (int)GL.CreateShader(ShaderType.FragmentShader);
        GL.ShaderSource((OpenTK.Graphics.ShaderHandle)pixelSharedHandle, pixelShaderCode);
        GL.CompileShader((OpenTK.Graphics.ShaderHandle)pixelSharedHandle);

        int SharedProgramHandle = (int)GL.CreateProgram();
        GL.AttachShader((OpenTK.Graphics.ProgramHandle)shaderProgramHandle, (OpenTK.Graphics.ShaderHandle)vertexSharedHandle);
        GL.AttachShader((OpenTK.Graphics.ProgramHandle)shaderProgramHandle, (OpenTK.Graphics.ShaderHandle)pixelSharedHandle);

        GL.LinkProgram((OpenTK.Graphics.ProgramHandle)shaderProgramHandle);

        GL.DetachShader((OpenTK.Graphics.ProgramHandle)shaderProgramHandle, (OpenTK.Graphics.ShaderHandle)vertexSharedHandle);
        GL.DetachShader((OpenTK.Graphics.ProgramHandle)shaderProgramHandle, (OpenTK.Graphics.ShaderHandle)pixelSharedHandle);

        GL.DeleteShader((OpenTK.Graphics.ShaderHandle)vertexSharedHandle);
        GL.DeleteShader((OpenTK.Graphics.ShaderHandle)pixelSharedHandle);

        base.OnLoad();
    }
    
    protected override void OnUnload()
    {
        GL.BindBuffer(BufferTargetARB.ArrayBuffer, (OpenTK.Graphics.BufferHandle)0);
        GL.DeleteBuffer((OpenTK.Graphics.BufferHandle)vertexBufferHandle);

        GL.UseProgram((OpenTK.Graphics.ProgramHandle)0);
        GL.DeleteProgram((OpenTK.Graphics.ProgramHandle)shaderProgramHandle);
        base.OnUnload();

    }

    
    
}


