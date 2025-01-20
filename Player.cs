using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator
{
    public class Player
    {
        private int days;       //存活天数
        private int hitPoint;   //生命值
        private int food;       //食物数量

        public int Days
        {
            get { return days; }
        }
        
        public int HitPoint
        {
            get { return hitPoint; }
        }

        public int Food
        {
            get { return food; }
        }

        public bool NextDay() //进入下一天
        {
            if (food > 0) { food--; } //食物不够扣10hp
            else { hitPoint -= 10; }

            if (HitPoint <= 0) //没血死亡
            { 
                return false;
            }
            else 
            { 
                days++;
                return true;
            }
        }

        public void GetFood(int quantity)
        {
            food += quantity;
        }

        public Player() 
        { 
            hitPoint = 100;
            food = 10;
            days = 1;
        }
    }
}
