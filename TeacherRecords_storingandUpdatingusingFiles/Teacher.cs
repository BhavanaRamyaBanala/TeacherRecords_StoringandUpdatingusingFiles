using System;

namespace TeacherRecords_storingandUpdatingusingFiles
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ClassNum { get; set; }
        public string Section { get; set; }

        public Teacher(int id, string name, int classNum, string section)
        {
            Id = id;
            Name = name;
            ClassNum = classNum;
            Section = section;
        }
    }
}