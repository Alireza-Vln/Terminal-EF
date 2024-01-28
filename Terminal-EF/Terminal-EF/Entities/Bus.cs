using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terminal_EF.Entities
{
    public class Bus
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public Type Type { get; set; }
        public int Capacity { get; set; }

        public HashSet<Chair> Chairs { get; set; }
        public HashSet<Trip> Trip { get; set; }
        public int SetCapacity()
        {
            if (Type == Type.Normal)
            {
                Capacity = 44;

            }
            if (Type == Type.Vip)
            {
                Capacity = 30;
            }
            return Capacity;
        }
        public void SetChair()
        {
            Chairs = new();
           
            
            for (int i = 1; i <= Capacity; i++)
            {
                var chair = new Chair();
                chair.IdNum = i;
                chair.Num=i.ToString();
                Chairs.Add(chair);
            }
        }
    } 


    
    public enum Type
    {
        Normal = 1,
        Vip = 2,
    }
    public class Chair
    {

        public int Id { get; set; }
        public int GroupId { get; set; }
        public int IdNum { get; set; }
        public Bus Bus { get; set; }
        public string Num { get; set; }
    }
}

