using System;
using System.Globalization;
using System.Reactive.Linq;
using System.Reflection;

namespace vd.core.extensions
{
    public static class ObjectExtensions
    {
        //public static IObserver<PropertyInfo> OnProcessing { get; private set; }

        public static T MapString<T>(this string val)
        {
            var data=val.Split("\t");

            PropertyInfo[] props=typeof(T).GetProperties(); 

            T newobj=(T)Activator.CreateInstance(typeof(T));

            
            //if(props.Length==data.Length)
            //{
                props.ToObservable().Subscribe(p=>OnProcessing(p,newobj,data));
            //}

            return newobj;
        }


        public static void OnProcessing(PropertyInfo prop, object obj,string[] data)
        {
            try
            {
                var lstattr=prop.GetCustomAttributes(true);
                FeedOrderAttribute attr=null;
                
                lstattr.ForEach(x=>{
                        if(x is FeedOrderAttribute)
                            attr=(FeedOrderAttribute)x;
                });

                
                if(attr.IsNotNull())
                {
                    var feedCounter=attr.Order;    
                    var convertType=attr.ConvertTo;
                    if(convertType.IsNotNull())
                    {
                        if(convertType==typeof(bool))  //this is to convert 1 or 0 from feed to true or false
                        {
                            if(data[feedCounter]=="1")
                            {
                                    prop.SetValue(obj,true);     
                            }   
                            else if(data[feedCounter]=="0")
                            {
                                    prop.SetValue(obj,false);
                            }
                        }

                        if(convertType==typeof(DateTime))
                        {
                           data[feedCounter].IfNotEmpty(x=>prop.SetValue(obj,Convert.ToDateTime(DateTime.ParseExact(x, "yyyyMMdd",CultureInfo.InvariantCulture).ToString("yyyy-MM-dd"))));
                        }

                    }
                    else
                    {
                        if(prop.PropertyType.Equals(typeof(int)))
                        {
                            data[feedCounter].IfNotEmpty(x=>prop.SetValue(obj,Convert.ToInt32(x)));
                        }

                        if(prop.PropertyType.Equals(typeof(Boolean)))
                        {
                            //prop.SetValue(obj,Convert.ToBoolean(data[feedCounter]));
                            //prop.SetValue(obj,data[feedCounter].FromNumericToBool());
                            data[feedCounter].IfNotEmpty(x=>prop.SetValue(obj,x.FromNumericToBool()));
                        }

                        if(prop.PropertyType.Equals(typeof(string)))
                        {
                            data[feedCounter].IfNotEmpty(x=>prop.SetValue(obj,Convert.ToString(x)));     
                        }

                        if(prop.PropertyType.Equals(typeof(double)))
                        {
                            data[feedCounter].IfNotEmpty(x=>prop.SetValue(obj,Convert.ToDouble(x)));     
                        }


                        if(prop.PropertyType.Equals(typeof(double?)))
                        {
                            data[feedCounter].IfNotEmpty(x=>prop.SetValue(obj,Convert.ToDouble(x)));
                        }

                        if(prop.PropertyType.Equals(typeof(decimal)))
                        {
                            data[feedCounter].IfNotEmpty(x=>prop.SetValue(obj,Convert.ToDecimal(x)));                                 
                        }

                        if(prop.PropertyType.Equals(typeof(decimal?)))
                        {
                            data[feedCounter].IfNotEmpty(x=>prop.SetValue(obj,Convert.ToDecimal(x)));                            
                        }

                        if(prop.PropertyType.Equals(typeof(DateTime)))
                        {
                            data[feedCounter].IfNotEmpty(x=>prop.SetValue(obj,x.ToDateTimeFromStr()));                            
                        }
                    }
                }

            }
            catch(Exception ex)
            {
                Console.WriteLine("** Exception **");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.InnerException.ToString());
                Console.WriteLine(ex.StackTrace);
            }
        }

        
        
    }
}