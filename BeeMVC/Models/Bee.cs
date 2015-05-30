using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeeMVC.Models
{
    public abstract class Bee
    {
        public float health = 100;
        protected float minHealth;
        public int beeType;
        public void damage(int pPercent)
        {
            this.health = this.health * (100 - pPercent) / 100;
        }
        public bool isDeath()
        {
            return (this.health < this.minHealth);
        }
    }
    public class Worker : Bee
    {
        public Worker()
        {
            this.minHealth = 70;
            beeType = 0;
        }
    }
    public class Queen : Bee
    {
        public Queen()
        {
            this.minHealth = 20;
            beeType = 1;
        }
    }
    public class Drone : Bee
    {
        public Drone()
        {
            this.minHealth = 50;
            beeType = 2;
        }
    }
}