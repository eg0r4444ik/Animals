using System.Collections.ObjectModel;
using System.Reflection;
using System.Text;
using System.Windows;

namespace Task3
{    
    public class MainViewModel
    {
        private object? task2Class = null;

        private String route = "C:\\tasks\\c#\\Task2\\Task2\\bin\\Debug\\net8.0-windows\\Task2.dll";       

        public List<string> nameClass { get; set; }

        public ObservableCollection<string> metodsClass { get; set; }

        public double Speed { get; set; }


        public MainViewModel()
        {
            nameClass = new List<string>();
            metodsClass = new ObservableCollection<string>();            
            getListClass();            
        }

        public void getListClass() 
        {
            nameClass = new List<string>();

            string assemblyPath = route;

            Assembly assembly = Assembly.LoadFrom(assemblyPath);

            Type[] types = assembly.GetTypes();

            var modelsTypes = types.Where(t => t.Namespace == "Task2.Model");

            foreach (Type type in modelsTypes)
            {
                nameClass.Add(type.FullName);
            }
        }

        public ObservableCollection<string> getListMetods(string nameClass)
        {
            metodsClass.Clear();

            Assembly assembly = Assembly.LoadFrom(route);

            Type classType = assembly.GetType(nameClass);

            MethodInfo[] methods = classType.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

            foreach (MethodInfo method in methods)
            {
                if (!method.IsSpecialName && method.Name.StartsWith("add_") == false && method.Name.StartsWith("remove_") == false)
                {
                    metodsClass.Add(method.Name);
                }
            }

            return metodsClass;
        }


        public void createClass(String className)
        {
            Assembly assembly = Assembly.LoadFrom(route);

            Type classType = assembly.GetType(className);

            if (classType != null)
            {
                task2Class = Activator.CreateInstance(classType);

                StringBuilder message = new StringBuilder($"Name: {classType.FullName}\n");

                FieldInfo[] fields = classType.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);

                foreach (FieldInfo field in fields)
                {
                    object value = field.GetValue(task2Class);

                    message.AppendLine($"{field.Name}: {value}");
                }
            }
            else
            {
                MessageBox.Show("Класс не найден");
            }
        }



        public object methodFromClass(string nameMethod)
        {
            try
            {
                if (task2Class == null)
                {
                    throw new InvalidOperationException("Класс не был выбран.");
                }

                MethodInfo method = task2Class.GetType().GetMethod(nameMethod);

                if (method == null)
                {
                    throw new MissingMethodException("Метод не найден.");
                }

                object returnValue = method.Invoke(task2Class, null);

                if (method.ReturnType != typeof(void))
                {
                    MessageBox.Show($"Результат выполнения метода: {method} - {returnValue}");
                }

                return returnValue;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка выполнения метода: {ex.Message}");
                return null;
            }
        }




        public void checkClass()
        {
            if (task2Class == null)
            {
                MessageBox.Show("Вы ещё не выбирали класс в первом выпадающем списке");
            }
            else
            {
                Type classType = task2Class.GetType();

                StringBuilder message = new StringBuilder($"Name: {classType.FullName}\n");

                PropertyInfo[] properties = classType.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy);

                foreach (PropertyInfo property in properties)
                {
                    object value = property.GetValue(task2Class);
                    message.AppendLine($"{property.Name}: {value}");
                }

                MessageBox.Show(message.ToString());
            }
        }



    }
}
