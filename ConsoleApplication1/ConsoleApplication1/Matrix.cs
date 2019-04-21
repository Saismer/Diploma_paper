using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Matrix
    {
        private int[,,] matrix_comparison_pairs;
        private double[,] matrix_loss;
        private double[,] matrix_loss_min;
        private double[] preliminary_ranking;
        private int[] bad_index;
        private int count_of_variant;
        private List<int> sort_variant;

        public void fill_martrix_comparison_pairs(int attribute_count, int variant_count, Kemeni_Snella[] obj)
        {
            matrix_comparison_pairs = new int[attribute_count, variant_count, variant_count];
            for (int i = 0; i < attribute_count; i++)
            {
                for (int j = 0; j < variant_count; j++)
                {
                    for (int k = 0; k < variant_count; k++)
                    {
                        if (j != k)
                        {
                            matrix_comparison_pairs[i, j, k] = obj[j].fill_elements_of_matrix_comparison(i, obj[k]);
                        }
                    }
                }
            }
        }

        public void fill_matrix_loss(int attribute_count, int variant_count, Saati saati)
        {
            matrix_loss = new double[variant_count, variant_count];
            sort_variant = new List<int>(variant_count);
            bad_index = new int[variant_count];
            for (int i = 0; i < attribute_count; i++)
            {
                for (int j = 0; j < variant_count; j++)
                {
                    for (int k = 0; k < variant_count; k++)
                    {
                        if (j != k)
                        {
                            matrix_loss[j, k] += saati.getWeight(i) * Math.Abs(matrix_comparison_pairs[i, j, k] - 1);
                        }
                    }
                }
            }

            for (int i = 0; i < variant_count; i++)
            {
                for (int j = 0; j < variant_count; j++)
                {
                    Console.Write("| " + matrix_loss[i, j].ToString() + " |");
                }
                Console.WriteLine();
            }
            fill_preliminary_ranking(variant_count, matrix_loss,sort_variant);
        }

        public void fill_preliminary_ranking(int variant_count, double[,] matrix,List<int> sort_variant)
        {            
            preliminary_ranking = new double[variant_count];

            for (int i = 0; i < variant_count; i++)
            {
                if (!sort_variant.Contains(i))
                {
                    for (int j = 0; j < variant_count; j++)
                    {
                        if (!sort_variant.Contains(j))
                            preliminary_ranking[i] += matrix[i, j];
                    }
                    Console.WriteLine(preliminary_ranking[i]);
                }
                else
                {
                    preliminary_ranking[i] = 999;
                }
            }

            find_best_variant(variant_count);
        }

        public void find_best_variant(int variant_count)
        {
            double best_value;
            int index;
            best_value = preliminary_ranking.Min();
            
            for (int i = 0; i < preliminary_ranking.Length; i++)
            {
                if (preliminary_ranking[i] == best_value)
                {
                    index = i;
                    sort_variant.Add(index);
                    //del_variant_from_matrix(index, variant_count);
                    break;
                }
            }
            if(variant_count - sort_variant.Count >= 1)
                fill_preliminary_ranking(variant_count, matrix_loss, sort_variant);
        }

        public void show_preliminary_ranking()
        {
            for(int i = 0;i<sort_variant.Count;i++)
            {
                Console.WriteLine(sort_variant[i]);
            }
        }

        public void final_ranking()
        {
            sort_variant.Reverse();
            for(int i =0; i < sort_variant.Count - 1;i++)
            {
                if(matrix_loss[sort_variant[i],sort_variant[i+1]] < matrix_loss[sort_variant[i], sort_variant[i + 1]])
                {
                    var buf = sort_variant[i];
                    sort_variant[i] = sort_variant[i + 1];
                    sort_variant[i + 1] = buf;
                }
            }
            
        }
        public void del_variant_from_matrix(int index, int variant_count)
        {
            matrix_loss_min = new double[variant_count - 1, variant_count - 1];
            int i1, j1 = 0;
            for (int i = 0; i < variant_count - 1; i++)
            {
                if (i >= index)
                {
                    i1 = i + 1;
                }
                else
                {
                    i1 = i;
                }
                for (int j = 0; j < variant_count - 1; j++)
                {
                    if (j >= index)
                    {
                        j1 = j + 1;
                    }
                    else
                    {
                        j1 = j;
                    }
                    matrix_loss_min[i, j] = matrix_loss[i1, j1];
                    Console.Write("| " + matrix_loss_min[i, j].ToString() + " |");
                }
                Console.WriteLine();
                //find_best_solution(variant_count - 1, matrix_loss_min);
            }

        }

        //public void find_best_solution(int variant_count, double[,] matrix)
        //{
        //    preliminary_ranking = new double[variant_count];
        //    for (int i = 0; i < variant_count; i++)
        //    {
        //        for (int j = 0; j < variant_count; j++)
        //        {
        //            preliminary_ranking[i] += matrix[i, j];
        //        }
        //        Console.WriteLine(preliminary_ranking[i]);
        //    }

        //    //if only 2 variant exist
        //    double best_value;
        //    int index;
        //    best_value = preliminary_ranking.Min();
        //    for (int i = 0; i < preliminary_ranking.Length; i++)
        //    {
        //        if (preliminary_ranking[i] == best_value)
        //        {
        //            index = i;
        //            sort_variant.Add(index);
        //        }
        //    }
        //    for(int )
        //}
    }
}
