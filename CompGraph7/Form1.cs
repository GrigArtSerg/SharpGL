using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime;
using SharpGL;

namespace CompGraph7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void openGLControl1_OpenGLDraw(object sender, SharpGL.RenderEventArgs args)
        {
            OpenGL gl = this.openGLControl1.OpenGL;
            float[] amb = { 0.7f, 0.7f, 0.7f, 1};
            float[] pos = { 0, 0, 5, 1};
            float[] dir = { 0, 0, -11 };
            float[] spec = { 1, 1, 1, 1 };

            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            gl.Enable(OpenGL.GL_DEPTH_TEST);
            gl.LoadIdentity();
            gl.Translate(0.0f, 0.0f, -15.0f);
            
            gl.Rotate((float)X.Value, 1.0, 0.0, 0.0);
            gl.Rotate((float)Y.Value, 0.0, 1.0, 0.0);
            gl.Rotate((float)Z.Value, 0.0, 0.0, 1.0);

            gl.Enable(OpenGL.GL_LIGHTING);
            gl.Enable(OpenGL.GL_LIGHT0);
            gl.Enable(OpenGL.GL_COLOR_MATERIAL);
            gl.Enable(OpenGL.GL_NORMALIZE);
            gl.Enable(OpenGL.GL_MATRIX_MODE);
            gl.Enable(OpenGL.GL_LIGHT_MODEL_TWO_SIDE);
            
            gl.MatrixMode(OpenGL.GL_PROJECTION);
            gl.MatrixMode(OpenGL.GL_MODELVIEW);
            
            gl.LightModel(OpenGL.GL_LIGHT_MODEL_TWO_SIDE, 1);
            
            gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_POSITION, pos);
            gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_AMBIENT, new [] {0, 0, 0, 1});
            gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_DIFFUSE, new[] { 1, 1, 1, 1});
            gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_SPECULAR, new[] { 1, 1, 1, 1 });
            gl.LightModel(OpenGL.GL_LIGHT_MODEL_AMBIENT, amb);

            gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_SPOT_DIRECTION, dir);
            

            gl.Material(OpenGL.GL_FRONT, OpenGL.GL_SPECULAR, spec);
            gl.Material(OpenGL.GL_FRONT, OpenGL.GL_SHININESS, 128.0f);
                   //  X, Y, Z
            float[] cords = { 0f, 0f, 0f,
                              0f, 0f, 1f,
                              0f, -1f, 1f,
                              0f, -1f, 0f,
                              1f, -1f, 0f,
                              1f, -1f, 1f,
                              1f, 0f, 1f,
                              1f, 0f, 0f };
            Desk(cords, gl);
            for (int e = 0; e < 2; e++)
            {
                for (int t = 1; t < 24; t += 3)
                {
                    cords[t] -= 2.2f;
                }
                for(int r = 2; r< 24; r+=3)
                {
                    cords[r] += 1.1f;
                }
                Desk(cords, gl);
            }
            
            
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {

        }

        void PaintCube(float[] Cords, OpenGL gl)
        {
            float[] navy = { 0f, 1f, 0f };
            float[] orange = { 1f, 0.63f, 0f };
            float[] green = { 0f, 0f, 1f };
            float[] red = { 1f, 0f, 0f };
            float[] white = { 1f, 1f, 1f };
            float[] yellow = { 1f, 0f, 1f };

            gl.Color(0f, 0f, 1f);//зеленый
            gl.Begin(OpenGL.GL_QUADS);

            gl.Material(OpenGL.GL_FRONT, OpenGL.GL_DIFFUSE, green);
            gl.Normal(0.0f, 0.0f, 1.0f);

            gl.Vertex(Cords[3], Cords[4], Cords[5]);//2
            gl.Vertex(Cords[6], Cords[7], Cords[8]);//3
            gl.Vertex(Cords[15], Cords[16], Cords[17]);//6
            gl.Vertex(Cords[18], Cords[19], Cords[20]);//7

            gl.End();

            gl.Color(1f, 0.63f, 0f);//оранжевый
            

            gl.Begin(OpenGL.GL_QUADS);

            gl.Material(OpenGL.GL_RIGHT, OpenGL.GL_DIFFUSE, orange);
            gl.Normal(1.0f, 0.0f, 0.0f);

            gl.Vertex(Cords[15], Cords[16], Cords[17]);//6
            gl.Vertex(Cords[18], Cords[19], Cords[20]);//7
            gl.Vertex(Cords[21], Cords[22], Cords[23]);//8
            gl.Vertex(Cords[12], Cords[13], Cords[14]);//5

            gl.End();

            gl.Color(0f, 1f, 0f);//синий
            gl.Begin(OpenGL.GL_QUADS);

            gl.Material(OpenGL.GL_BACK, OpenGL.GL_DIFFUSE, navy);
            gl.Normal(0.0f, 0.0f, -1.0f);

            gl.Vertex(Cords[21], Cords[22], Cords[23]);//8
            gl.Vertex(Cords[12], Cords[13], Cords[14]);//5
            gl.Vertex(Cords[9], Cords[10], Cords[11]);//4
            gl.Vertex(Cords[0], Cords[1], Cords[2]);//1

            gl.End();

            gl.Color(1f, 0f, 0f);//красный
            gl.Begin(OpenGL.GL_QUADS);

            gl.Material(OpenGL.GL_LEFT, OpenGL.GL_DIFFUSE, red);
            gl.Normal(0.0f, -1.0f, 0.0f);

            gl.Vertex(Cords[9], Cords[10], Cords[11]);//4
            gl.Vertex(Cords[0], Cords[1], Cords[2]);//1
            gl.Vertex(Cords[3], Cords[4], Cords[5]);//2
            gl.Vertex(Cords[6], Cords[7], Cords[8]);//3

            gl.End();

            gl.Color(1f, 1f, 1f);//белый
            gl.Begin(OpenGL.GL_QUADS);

            gl.Material(OpenGL.GL_FRONT, OpenGL.GL_DIFFUSE, white);
            gl.Normal(0.0f, 1.0f, 0.0f);

            gl.Vertex(Cords[0], Cords[1], Cords[2]);//1
            gl.Vertex(Cords[3], Cords[4], Cords[5]);//2
            gl.Vertex(Cords[18], Cords[19], Cords[20]);//7
            gl.Vertex(Cords[21], Cords[22], Cords[23]);//8

            gl.End();

            gl.Color(1f, 1f, 0f);//желтый
            gl.Begin(OpenGL.GL_QUADS);

            gl.Material(OpenGL.GL_BACK, OpenGL.GL_DIFFUSE, yellow);
            gl.Normal(-1.0f, 0.0f, 0.0f);

            gl.Vertex(Cords[6], Cords[7], Cords[8]);//3
            gl.Vertex(Cords[9], Cords[10], Cords[11]);//4
            gl.Vertex(Cords[12], Cords[13], Cords[14]);//5
            gl.Vertex(Cords[15], Cords[16], Cords[17]);//6

            gl.End();
        }

        void Line(float[] cords, OpenGL gl)
        {
            PaintCube(cords, gl);
            for (int j = 0; j < 2; j++)
            {
                for (int i = 0; i < 24; i += 3)
                {
                    cords[i] += 1.1f;
                }
                PaintCube(cords, gl);
            }
        }

        void Desk(float[] cords, OpenGL gl)
        {
            for (int q = 0; q < 2; q++)
            {
                Line(cords, gl);
                for (int i = 0; i < 24; i += 3)
                {
                    cords[i] -= 2.2f;
                }
                for (int w = 1; w < 24; w += 3)
                {
                    cords[w] += 1.1f;
                }
                Line(cords, gl);
                for (int i = 0; i < 24; i += 3)
                {
                    cords[i] -= 2.2f;
                }

            }
        }
    }
}
