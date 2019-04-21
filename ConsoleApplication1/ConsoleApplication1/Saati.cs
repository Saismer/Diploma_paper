using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Saati
    {
        private double[,] pair_matrix_comparison =
        {
           {1,      5,      7,      9},
           {Math.Pow(5,-1),    1,      5,      7},
           {Math.Pow(7,-1),    Math.Pow(5,-1),    1,      3},
           {Math.Pow(9,-1),    Math.Pow(7,-1),    Math.Pow(3,-1),    1}
        };

        private double[] cost_variant;
        private double final_cost_variant;
        private double[] weight_variant;
        private const int count_attribute = 4;

        public Saati()
        {
            cost_variant = new double[count_attribute];
            weight_variant = new double[count_attribute];
            final_cost_variant = 0;
        }
        public double getWeight(int index)
        {
            return this.weight_variant[index];
        }
        public int get_count_attribute()
        {
            return count_attribute;
        }
        public void find_cost_variants()
        {
            double mult_matrix_line = 1;
            for (int i = 0; i < count_attribute; i++)
            {
                for (int j = 0; j < count_attribute; j++)
                {
                    mult_matrix_line *= this.pair_matrix_comparison[i, j];
                }
                this.cost_variant[i] = Math.Pow(mult_matrix_line, Math.Pow(4,-1));
                mult_matrix_line = 1;
                Console.WriteLine(this.cost_variant[i]);
            }

        }

        public void find_weight_variants()
        {
            for(int i = 0;i<this.cost_variant.Length;i++)
            {
                this.final_cost_variant += this.cost_variant[i];
            }

            for(int i = 0;i<this.weight_variant.Length;i++)
            {
                this.weight_variant[i] = this.cost_variant[i] / this.final_cost_variant;
                Console.WriteLine(this.weight_variant[i]);
            }

        }

        public void all_methods()
        {
            Console.WriteLine("Cost variants");
            this.find_cost_variants();
            Console.WriteLine("Weight variants");
            this.find_weight_variants();
        }
    }
}
