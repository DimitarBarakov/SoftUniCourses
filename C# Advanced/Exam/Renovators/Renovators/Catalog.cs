using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renovators
{
    public class Catalog
    {
        private string name;
        private int neededRenovators;
        private string project;
        private List<Renovator> renovators;

        public List<Renovator> Renovators
        {
            get { return renovators; }
            set { renovators = value; }
        }


        public string Project
        {
            get { return project; }
            set { project = value; }
        }


        public int NeededRenovators
        {
            get { return neededRenovators; }
            set { neededRenovators = value; }
        }


        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Count { get => Renovators.Count; }

        public Catalog(string name, int neededRenovators, string project)
        {
            Renovators = new List<Renovator>();
            Name = name;
            NeededRenovators = neededRenovators;
            Project = project;
        }

        public string AddRenovator(Renovator renovator)
        {
            if (renovator.Name == String.Empty)
            {
                return "Invalid renovator's information.";
            }
            else if (renovator.Name == null)
            {
                return "Invalid renovator's information.";
            }
            else if (renovator.Type == String.Empty)
            {
                return "Invalid renovator's information.";
            }
            else if (renovator.Type == null)
            {
                return "Invalid renovator's information.";
            }
            else if (Count == NeededRenovators)
            {
                return "Renovators are no more needed.";
            }
            else if (renovator.Rate >= 350)
            {
                return "Invalid renovator's rate.";
            }
            else
            {
                Renovators.Add(renovator);
                return $"Successfully added {renovator.Name} to the catalog.";
            }
        }

        public bool RemoveRenovator(string name)
        {
            if (Renovators.Any(r => r.Name == name))
            {
                Renovators.Remove(Renovators.First(r => r.Name == name));
                return true;
            }
            return false;
        }

        public int RemoveRenovatorBySpecialty(string type)
        {
            List<Renovator> removed = Renovators.Where(r => r.Type == type).ToList();
            Renovators.RemoveAll(r => r.Type == type);
            return removed.Count;
        }

        public Renovator HireRenovator(string name)
        {
            if (Renovators.Any(r => r.Name == name))
            {
                Renovators.First(r => r.Name == name).Hired = true;
                return Renovators.First(r => r.Name == name);
            }
            return null;
        }

        public List<Renovator> PayRenovators(int days)
        {
            List<Renovator> payed = Renovators.Where(r => r.Days >= days).ToList();
            return payed;
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Renovators available for Project {Project}:");
            foreach (var ren in Renovators)
            {
                sb.AppendLine(ren.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
