using gdproject.Input;
using gdproject.Interfaces;
using Microsoft.Win32.SafeHandles;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gdproject.Animation
{
    internal class AnimationManager
    {
        public Animatie CurrentAnimation { get; set; }
        public AnimationFrame CurrentFrame { get; set; }

        private Animatie stillAnimatie = new Animatie();
        private Animatie runAnimatie = new Animatie();
        private Animatie smashAnimatie = new Animatie();
        private Animatie danceAnimatie = new Animatie();
        private IInputReader inputReader; 
        private int frameSize = 64;

        public AnimationManager(IInputReader inputReader)
        {
            AnimationInit(stillAnimatie, 4, 0);
            AnimationInit(runAnimatie, 6, 1);
            AnimationInit(smashAnimatie, 12, 5);
            AnimationInit(danceAnimatie, 6, 9);
            this.inputReader = inputReader;

            CurrentAnimation = danceAnimatie;
        }

        private void AnimationInit(Animatie an, int frames, int line)
        {

            for (int i = 0; i < frames; i++)
            {
                an.AddFrame(new AnimationFrame(new Rectangle(i * frameSize, frameSize * line, frameSize, frameSize )));
            }
        }

        public void Update(GameTime gameTime)
        {
            CurrentAnimation.Update(gameTime);
            CurrentFrame = CurrentAnimation.CurrentFrame;
            Movement an = inputReader.ReadInput();
            if(an == Movement.left || an == Movement.right || an == Movement.up)
            {
                CurrentAnimation = runAnimatie;
            }
            if (an == Movement.smash)
            {
                CurrentAnimation = smashAnimatie;
            }
            if (an == Movement.dance)
            {
                CurrentAnimation = danceAnimatie;
            }
            if (an == Movement.still)
            {
                CurrentAnimation = stillAnimatie;
            }
        }
    }
}
