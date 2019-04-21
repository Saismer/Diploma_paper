using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Kemeni_Snella
    {
        private int communication_index;
        private int infrastructure_index;
        private double distance;
        private int cost;
        private Dictionary<int, bool> communication;
        private Dictionary<int, string> infrastructure;
        private int[] paretto;
        private const int count_attributes = 4;
       // private FieldInfo[] list_of_properties;
        //Type type_of_class = typeof(Kemeni_Snella);

        public Kemeni_Snella(bool communication_index, string infrastructure_index, double distance, int cost)
        {
            communication = new Dictionary<int, bool>(2)
            {
                { 1, true },
                { 2, false }
            };
            infrastructure = new Dictionary<int, string>(3)
            {
                { 1,"good"},
                { 2,"medium"},
                { 3,"bad"}
            };

            this.distance = distance;
            this.cost = cost;
            this.communication_index = this.communication.FirstOrDefault(x => x.Value == communication_index).Key;
            this.infrastructure_index = this.infrastructure.FirstOrDefault(x => x.Value == infrastructure_index).Key;
            //list_of_properties = type_of_class.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
        }

        public void fill_initial_matrix(Kemeni_Snella obj)
        {
            this.paretto = new int[count_attributes];

            //communication value
            if (this.communication_index < obj.communication_index)
                this.paretto[0] = 1;
            else if (this.communication_index > obj.communication_index)
                this.paretto[0] = -1;
            else
                this.paretto[0] = 0;

            //infrastucture value
            if (this.infrastructure_index < obj.infrastructure_index)
                this.paretto[1] = 1;
            else if (this.infrastructure_index > obj.infrastructure_index)
                this.paretto[1] = -1;
            else
                this.paretto[1] = 0;

            //distance value
            if (this.distance < obj.distance)
                this.paretto[2] = 1;
            else if (this.distance > obj.distance)
                this.paretto[2] = -1;
            else
                this.paretto[2] = 0;

            //cost value
            if (this.cost < obj.cost)
                this.paretto[3] = 1;
            else if (this.cost > obj.cost)
                this.paretto[3] = -1;
            else
                this.paretto[3] = 0;
        }

        public bool exclude_variant(Kemeni_Snella obj)
        {
            bool[] medium_check = new bool[count_attributes];

            if (obj == null)
            {
                //Object doesn't exist
                return true;
            }

            fill_initial_matrix(obj);
            if (Array.Exists(this.paretto, x => x == 1) && Array.Exists(this.paretto, x => x == -1))
                return true;
            else if (!Array.Exists(this.paretto, x => x == -1))
                return true;
            else
                return false;
        }

        public int fill_elements_of_matrix_comparison(int index,Kemeni_Snella obj)
        {

            fill_initial_matrix(obj);
            if (this.paretto[index] == 0)
                return 0;
            else if (this.paretto[index] == 1)
                return 1;
            else       
                return -1;        
        }
    }
}
