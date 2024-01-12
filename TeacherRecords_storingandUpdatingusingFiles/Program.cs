using System;
using System.Collections.Generic;
using System.IO;
using TeacherRecords_storingandUpdatingusingFiles;


namespace TeacherRecords_storingandUpdatingusingFiles
{
    class Program
    {
        public static string filePath = @"D:\dotNet\TeacherRecords_storingandUpdatingusingFiles\TeachersRecordsFile.txt";

        public static void WriteData()
        {
            FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine("This File contains Teacher Records");
            sw.WriteLine("ID \t\t Name \t\t Class \t\t Section");

            sw.Close();
            fs.Close();
        }


        public static void AppendData()
        {
            FileStream fs = new FileStream(filePath, FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            try
            {
                Console.Write("Add Teacher's ID:");
                int id = Convert.ToInt32(Console.ReadLine());
                Console.Write("Add Teacher's Name:");
                string name = Console.ReadLine();
                Console.Write("Add Teacher's Class Number:");
                int classNum = Convert.ToInt32(Console.ReadLine());
                Console.Write("Add Teacher's Section:");
                string section = Console.ReadLine();

                Teacher t1 = new Teacher(id, name, classNum, section);
                sw.WriteLine("{0} \t\t {1} \t\t {2} \t\t {3}", t1.Id, t1.Name, t1.ClassNum, t1.Section);
                Console.WriteLine("New Teacher data added successfully!!\n");
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e1)
            {
                Console.WriteLine(e1.Message);
            }
            finally
            {
                sw.Close();
                fs.Close();
            }

        }


        public static void ReadData()
        {
            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            sr.BaseStream.Seek(0, SeekOrigin.Begin);
            string str = sr.ReadLine();
            while (str != null)
            {
                Console.WriteLine(str);
                str = sr.ReadLine();
            }
            sr.Close();
            fs.Close();
        }


        public static void UpdateData(int id)
        {
            FileStream fs3 = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            StreamReader sr3 = new StreamReader(fs3);

            try
            {
                Console.Write("Add Teacher's Name:");
                string name = Console.ReadLine();
                Console.Write("Add Teacher's Class:");
                int classNum = Convert.ToInt32(Console.ReadLine());
                Console.Write("Add Teacher's Section:");
                string section = Console.ReadLine();

                Teacher t1 = new Teacher(id, name, classNum, section);
                string updatedData = $"{t1.Id} \t\t {t1.Name} \t\t {t1.ClassNum} \t\t{t1.Section}";

                string[] lines;
                using (fs3)
                {
                    using (sr3)
                    {
                        lines = File.ReadAllLines(filePath);

                        for (int i = 2; i < lines.Length; i++)
                        {
                            string[] split = lines[i].Split(',');
                            foreach (var item in split)

                            {
                                if (Char.GetNumericValue(item[0]) == id)
                                {
                                    lines[i] = updatedData;
                                }
                            }
                        }

                        foreach (var item in lines)
                        {
                            Console.WriteLine(item);
                        }
                    }
                }

                using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        foreach (var item in lines)
                        {
                            sw.WriteLine(item);
                        }
                    }
                }

            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex1)
            {
                Console.WriteLine(ex1.Message);
            }

        }

        static void Main(string[] args)
        {
            
                while (true)
                {
                    Console.WriteLine(" --Teacher Records System-- ");
                    Console.WriteLine(" 1  Enter New data  ");
                    Console.WriteLine(" 2  Update Existing data  ");
                    Console.WriteLine(" 3  Display Teacher records");
                    Console.WriteLine(" 4  Exit \n");
                int n1 = Convert.ToInt32(Console.ReadLine());
                if (n1 == 1)
                {
                    WriteData();
                    AppendData();
                }
                else if (n1 == 2)
                {

                    ReadData();
                    Console.Write("Please enter teacher's ID to update:");
                    int id = Convert.ToInt32(Console.ReadLine());
                    UpdateData(id);
                }
                else if (n1 == 3)
                {
                    ReadData();
                }
                Console.WriteLine("do you want to continue Press (yes/no)");
                string s11 = Console.ReadLine();
                if (s11.Equals("yes"))
                {
                    Main(args);
                }
                else
                {

                }

            }
            
        }
    }
}
