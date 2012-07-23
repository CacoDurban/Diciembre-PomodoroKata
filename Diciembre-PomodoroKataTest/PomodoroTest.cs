using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit;
using NUnit.Framework;
using Diciembre_PomodoroKata;

namespace Diciembre_PomodoroKataTest
{
    [TestFixture]
    public class PomodoroTest
    {

        [Test]
        public void Un_pomodoro_dura_25_minutos_defecto()
        {
            TimeSpan Duracion = new TimeSpan(0, 25, 0);

            Pomodoro pomodoro = new Pomodoro();

            Assert.AreEqual(Duracion, pomodoro.Duracion);
        }

        [Test]
        public void Puedo_crear_un_pomodoro_con_cualquier_duracion()
        {
            TimeSpan Duracion = new TimeSpan(0, 30, 0);

            Pomodoro pomodoro = new Pomodoro(Duracion);

            Assert.AreEqual(Duracion, pomodoro.Duracion);
        }

        [Test]
        public void Un_pomodoro_esta_parado_nada_mas_creado()
        {
            Pomodoro pomodoro = new Pomodoro();

            Assert.AreEqual(Estado.Parado, pomodoro.Estado);
        }

        [Test]
        public void Al_arrancar_el_pomodoro_la_cuenta_atras_comienza()
        {

            Pomodoro pomodoro = new Pomodoro(new TimeSpan(0, 0, 10));

            pomodoro.Start();

            Assert.IsTrue(pomodoro.TiempoDisponible <= new TimeSpan(0, 0, 10));
        }

        [Test]
        public void Un_Pomodoro_termina_cuando_termina_su_tiempo()
        {
            Pomodoro pomodoro = new Pomodoro(new TimeSpan(0, 0, 1));

            pomodoro.Start();

            System.Threading.Thread.Sleep(1000);

            Assert.AreEqual(pomodoro.Estado, Estado.Terminado);

        }

        [Test]
        public void Un_Pomodoro_no_termina_hasta_que_no_se_agote_su_tiempo()
        {
            Pomodoro pomodoro = new Pomodoro();

            pomodoro.Start();
            
            Assert.AreEqual(pomodoro.Estado, Estado.Lanzado);
        }


        [Test]
        public void Un_pomodoro_se_inicia_sin_interupciones()
        {
            Pomodoro pomodoro = new Pomodoro();

            Assert.AreEqual(0,pomodoro.Interrupciones);
        }

        [Test]
        public void Un_pomodoro_sino_esta_iniciado_no_se_puede_interrumpir()
        {
            Pomodoro pomodoro = new Pomodoro();

            pomodoro.Interrumpir();

            Assert.AreEqual(Estado.Parado, pomodoro.Estado);
        }

        [Test]
        public void Un_pomodoro_cuenta_las_interrupciones()
        {

            Pomodoro pomodoro = new Pomodoro();

            pomodoro.Start();

            pomodoro.Interrumpir();

            Assert.AreEqual(1, pomodoro.Interrupciones);
            
        }

        [Test]
        public void Un_pomodoro_arrancado_se_reinicia()
        {
            Pomodoro pomodoro = new Pomodoro();

            pomodoro.Start();

            pomodoro.Reiniciar();

            Assert.AreEqual(new TimeSpan(0, 25, 0), pomodoro.Duracion);
        }

        [Test]
        public void Un_pomodo_se_reinicia_sin_interrupciones()
        {
            Pomodoro pomodoro = new Pomodoro();

            pomodoro.Start();

            pomodoro.Reiniciar();

            Assert.AreEqual(0, pomodoro.Interrupciones);
        }



    
    }
}
