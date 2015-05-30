using BeeMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeeMVC.Function
{
    public class BeeManager
    {
        const int BEE_TYPE_COUNT = 3;
        public List<Bee> mBees = new List<Bee>();
        
        public List<Bee> InitializeList(Random pRandom)
        {
            this.mBees.Clear();
            int[] beeTypeRemain = new int[BEE_TYPE_COUNT];
            for (int i = 0; i < BEE_TYPE_COUNT; i++)
                beeTypeRemain[i] = 10;
            for (int i = 0; i < BEE_TYPE_COUNT * 10; i++)
            {
                int type;
                do
                    type = pRandom.Next(beeTypeRemain.Length);
                while (beeTypeRemain[type] == 0);
                beeTypeRemain[type]--;
                this.mBees.Add(type == 0 ? new Worker() : (type == 1 ? (Bee)(new Queen()) : new Drone()));
            }          
            return mBees;
        }
        public List<Bee> DamageAll(List<Bee> bees,Random pRandom)
        {
            for (int i = 0; i < bees.Count(); i++)
            {
                bees[i].damage(bees[i].isDeath() ? 0 : pRandom.Next(80 + 1));
            }
            return bees;
        }
    }
}