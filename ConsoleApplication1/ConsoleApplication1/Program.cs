using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{

    class Program
    {
        static void Main(string[] args)
        {
            bool[] test = new bool[5];

            Kemeni_Snella[] all_lands = new Kemeni_Snella[5];

            Kemeni_Snella kemeni_snella_1 = new Kemeni_Snella(true,"good",300,50000);
            //kemeni_snella_1.fill_elements_of_matrix_comparison();
            Kemeni_Snella kemeni_snella_2 = new Kemeni_Snella(false, "medium", 100, 40000);
            Kemeni_Snella kemeni_snella_3 = new Kemeni_Snella(true, "bad", 200, 35000);
            Kemeni_Snella kemeni_snella_4 = new Kemeni_Snella(true, "good", 250, 45000);
            Kemeni_Snella kemeni_snella_5 = new Kemeni_Snella(false, "good", 50, 40000);

            all_lands[0] = kemeni_snella_1;
            all_lands[1] = kemeni_snella_2;
            all_lands[2] = kemeni_snella_3;
            all_lands[3] = kemeni_snella_4;
            all_lands[4] = kemeni_snella_5;
            
            for(int i = 0;i<all_lands.Length; i++)
            {
                for(int j=0; j<all_lands.Length; j++)
                {
                    test[i] = all_lands[i].exclude_variant(all_lands[j]);
                    if(!test[i])
                    {
                        test[i] = false;
                        all_lands[i] = null;
                        break;
                    }                       
                }
            }

            all_lands = Array.FindAll(all_lands, x => x != null);

            for(int i=0;i<test.Length;i++)
            {
                Console.WriteLine(test[i]);
            }

            Saati cost_varint = new Saati();
            cost_varint.all_methods();

            Matrix matrix = new Matrix();
            matrix.fill_martrix_comparison_pairs(cost_varint.get_count_attribute(),all_lands.Length, all_lands);

            matrix.fill_matrix_loss(cost_varint.get_count_attribute(), all_lands.Length, cost_varint);
            matrix.final_ranking();
            matrix.show_preliminary_ranking();
            
         }
    }
}
