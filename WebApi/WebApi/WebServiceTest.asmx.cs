using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Services;
using WebApi.Controllers;
using WebApi.Models;
using Newtonsoft.Json;

namespace WebApi
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        //// заполнение тестовыми данными, выполнено через Ado. получилось быстрей
        //[WebMethod]
        //public string FullObjects(int levelCount, int typeCount, int elementCount)
        //{
        //    AttributesController attrController = new AttributesController();
        //    ObjectsController objController = new ObjectsController();
        //    RefObjectsController refObjController = new RefObjectsController();
        //    ClassesController clController = new ClassesController();
        //    RefClassesController refClController = new RefClassesController();

        //    IList<Classes> qClasses = clController.GetClasses().OrderBy(x => x.id).ToArray();

        //    Random rnd = new Random();

        //    List<Objects> listNewObjects = new List<Objects>();
        //    List<RefObjects> listNewRefObjects = new List<RefObjects>();

        //    //IList<Objects> list = objController.GetObjects().ToList();
        //    IList<RefClasses> listRefCl = refClController.GetRefClasses().ToList();
        //    IList<Attributes> listAttrs = attrController.GetAttributes().ToList();

        //    //for (int i = 0; i < list.Count; i++)
        //    for (int i = 0; i < elementCount; i++)
        //    {
        //        Objects obj = new Objects();
        //        // получаем ссылку на класс
        //        int rndClass = rnd.Next(0, typeCount);
        //        obj.idClass = qClasses[rndClass].id;
        //        obj.name = string.Format("{0}{1}", qClasses[rndClass].name, new Random().Next(1, 100000));
        //        // получаем ссылку на родителя
        //        if (listNewObjects.Count > 0)
        //        //if (list.Count > 0)
        //        //if (objController.GetObjects().ToList().Count > 0)
        //        {
        //            int rndParent = rnd.Next(1, levelCount + 1);
        //            if (rndParent == 1)
        //            {
        //                obj.idParent = null;
        //                obj.due = string.Format("{0}.", obj.id);
        //            }
        //            else
        //            {
        //                bool bLevel = true;
        //                IList<Objects> qObjects = new List<Objects>();
        //                while (bLevel)
        //                {
        //                    bLevel = false;

        //                    qObjects = listNewObjects.Where(x => x.due.Count(q => q == '.') == (rndParent - 1)).Select(x => x).ToList();
        //                    //qObjects = list.Where(x => x.due.Count(q => q == '.') == (rndParent - 1)).Select(x => x).ToList();
        //                    //qObjects = objController.GetObjects().ToList().Where(x => x.due.Count(q => q == '.') == (rndParent - 1)).Select(x => x).ToList();
        //                    if (qObjects.Count == 0)
        //                    {
        //                        bLevel = true;
        //                        qObjects = new List<Objects>();
        //                        rndParent--;
        //                    }
        //                }

        //                int rndParentObject = rnd.Next(0, qObjects.Count);
        //                obj.idParent = qObjects[rndParentObject].id;


        //                string curDue = qObjects[rndParentObject].due;
        //                obj.due = string.Format("{0}{1}.", curDue, obj.id);
        //            }
        //        }
        //        else
        //        {
        //            obj.idParent = null;
        //            obj.due = string.Format("{0}.", obj.id);
        //        }

        //        // записывае объект
        //        //objController.PostObjects(obj);
        //        listNewObjects.Add(obj);


        //        ////Objects obj = list[i];

        //        string[] ids = listRefCl.Where(x => x.idClass == obj.idClass).Select(q => q.idAttribute).ToArray();
        //        foreach (string idAttr in ids)
        //        {
        //            RefObjects refObj = new RefObjects();
        //            refObj.idObjects = obj.id;
        //            refObj.idAttributes = idAttr;
        //            //todo 
        //            refObj.value = (string.Equals(listAttrs.First(x => x.id == idAttr).idTypes, "6")) ? string.Format("string{0}", new Random().Next(1, 10000)) : string.Format("{0}", new Random().Next(1, 10000) / 100);

        //            // записываем значения
        //            //refObjController.PostRefObjects(refObj);
        //            listNewRefObjects.Add(refObj);
        //        }
        //    }


        //    //listNewObjects.ForEach(x => objController.PostObjects(x));
        //    listNewObjects.ForEach(x => objController.db.Objects.Add(x));
        //    listNewRefObjects.ForEach(x => refObjController.db.RefObjects.Add(x));

        //    //listNewObjects.ForEach(x => objController.db.Objects.Add(x));
        //    objController.db.SaveChanges();
        //    refObjController.db.SaveChanges();

        //    //objController.PostObjects(obj);

        //    return "Тестовые объекты созданы";
        //}

        //[WebMethod]
        //public string EditParentId(int levelCount, int typeCount)
        //{
        //    AttributesController attrController = new AttributesController();
        //    ObjectsController objController = new ObjectsController();
        //    RefObjectsController refObjController = new RefObjectsController();
        //    ClassesController clController = new ClassesController();
        //    RefClassesController refClController = new RefClassesController();

        //    IList<Objects> list = objController.GetObjects().ToList();
        //    IList<Classes> qClasses = clController.GetClasses().OrderBy(x => x.id).ToArray();

        //    for (int i = 0; i < list.Count; i++)
        //    {
        //        Objects obj = list[i];

        //        //if (!obj.idParent.HasValue)
        //        //{
        //        //    continue;
        //        //}

        //        int rndParent = new Random().Next(1, levelCount + 1);
        //        //if (i == 0)
        //        //{
        //        //    rndParent = 1;
        //        //}

        //        List<Objects> listObj = objController.GetObjects().ToList();

        //        if (rndParent == 1 || obj.due.Count(q => q == '.') > 1)
        //        { }
        //        else
        //        {
        //            bool bLevel = true;
        //            IList<Objects> qObjects = new List<Objects>();
        //            while (bLevel)
        //            {
        //                bLevel = false;

        //                if (rndParent == 1)
        //                {
        //                    continue;
        //                }
        //                qObjects = listObj.Where(x => x.due.Count(q => q == '.') == (rndParent - 1)).Select(x => x).ToList();
        //                //qObjects = listObj.Where(x => x.due.Count(q => q == '.') == (rndParent - 1) && x.id < obj.id).Select(x => x).ToList();
        //                if (qObjects.Count == 0)
        //                {
        //                    bLevel = true;
        //                    qObjects = new List<Objects>();
        //                    rndParent--;
        //                }
        //            }

        //            int rndParentObject = new Random().Next(0, qObjects.Count);
        //            obj.idParent = qObjects[rndParentObject].id;

        //            objController.PutObjects(obj.id, obj);
        //        }
        //    }

        //    return "Тестовые объекты созданы";
        //}


        // задача 1

        [WebMethod]
        public string CreateObject(string name, string idClass, string idParent)
        {
            string error = string.Empty;

            if (string.IsNullOrEmpty(name))
            {
                error += "\r\n У объекта не задано имя.";
            }
            if (string.IsNullOrEmpty(idClass))
            {
                error += "\r\n Не задан класс объекта.";
            }

            if (!string.IsNullOrEmpty(error))
            {
                return error;
            }

            Objects obj = new Objects();
            obj.name = name;
            obj.idClass = idClass;
            obj.idParent = idParent;

            ObjectsController objController = new ObjectsController();
            objController.PostObjects(obj);

            return string.Format("Объект создан");
        }

        // задача 2
        [WebMethod]
        public string DeleteObjects(string id)
        {
            ObjectsController objController = new ObjectsController();

            IList<Objects> listObj = objController.GetObjects().ToList();

            if (!listObj.Any(x => string.Equals(x.id, id)))
            {
                return string.Format("Объекс с иденитификатором {0} не найден.", id);
            }

            Objects objects = listObj.First(x => string.Equals(x.id, id));

            // удаляем все зависимые объекты RefОbjects
            DeleteRefObjects(objects);

            // удаляем все подчиненные Objects
            DeleteSubObjects(objects);

            objController = new ObjectsController();
            objController.DeleteObjects(id);

            return string.Format("Объект вместе с поддеревом с иденитификатором {0} удален.", id);
        }

        // задача 3
        [WebMethod]
        public string GetTreeObjects(string id)
        {
            // на выходе имя и due код в котором представлена вся иерархия
            ObjectsController objController = new ObjectsController();

            // достаточно првоерять вхождение, а не индекс, так как любой код начинается с '0.'
            // сортировка по убыванию номера, так как будем удалять все элементы дерева начиная с конца

            if (!objController.GetObjects().ToList().Any(x => string.Equals(x.id, id)))
            {
                return string.Format("Объект не найден.");
            }

            Objects obj = objController.GetObjects().ToList().FirstOrDefault(x => string.Equals(x.id, id));


            IList<KeyValuePair<string, string>> list = objController.GetObjects().ToList().Where(x => x.due.Contains(obj.due)).Select(x => new KeyValuePair<string, string>(x.name, x.due)).ToList();

            return JsonConvert.SerializeObject(list);
        }

        // задача 4
        [WebMethod]
        public string GetFullObjectsById(string id)
        {
            ObjectsController objController = new ObjectsController();
            RefObjectsController refObjController = new RefObjectsController();

            IList<Objects> listObj = objController.GetObjects().ToList();

            if (!listObj.Any(x => string.Equals(x.id, id)))
            {
                return null;
            }

            Objects obj = listObj.FirstOrDefault(x => string.Equals(x.id, id));
            
            return JsonConvert.SerializeObject(obj, Formatting.Indented,
                new JsonSerializerSettings
                {
                    PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
        }

        // задача 5
        [WebMethod]
        public string EditAttribute(string idObject, string idAttribute, string value)
        {
            string error = string.Empty;

            if (string.IsNullOrEmpty(idObject))
            {
                error += "\r\n Не задан объект.";
            }
            if (string.IsNullOrEmpty(idAttribute))
            {
                error += "\r\n Не задан атрибут.";
            }
            if (string.IsNullOrEmpty(idAttribute))
            {
                error += "\r\n Не задано значение атрибута.";
            }

            if (!string.IsNullOrEmpty(error))
            {
                return error;
            }

            RefObjectsController refObjController = new RefObjectsController();

            IList<RefObjects> listObj = refObjController.GetRefObjects().ToList();

            if (!listObj.Any(x => string.Equals(x.idObjects, idObject) && string.Equals(x.idAttributes, idAttribute)))
            {
                return string.Format("Объекс {0} с атрибутом {1} не найден.", idObject, idAttribute);
            }

            RefObjects refObj = listObj.FirstOrDefault(x => string.Equals(x.idObjects, idObject) && string.Equals(x.idAttributes, idAttribute));
            refObj.value = value;

            refObjController.PutRefObjects(refObj.id, refObj);

            return string.Format("Атрибут {0} объекта {1} отправлен на обновление.", idAttribute, idObject);
        }

        // ищем подчиненные объекты и отправляем на удаление
        private void DeleteSubObjects(Objects obj)
        {
            ObjectsController objController = new ObjectsController();

            // достаточно првоерять вхождение, а не индекс, так как любой код начинается с '0.'
            // сортировка по убыванию номера, так как будем удалять все элементы дерева начиная с конца
            IList<Objects> query = objController.GetObjects().ToList().Where(x => x.due.Contains(obj.due)).OrderByDescending(x => x.id).ToList();

            foreach (Objects subObj in query)
            {
                DeleteRefObjects(subObj);

                objController.DeleteObjects(subObj.id);
            }
        }

        // удаляем все зависимые объекты RefОbjects
        private void DeleteRefObjects(Objects obj)
        {
            RefObjectsController refObjController = new RefObjectsController();

            IList<RefObjects> query = refObjController.GetRefObjects().ToList().Where(x => int.Equals(x.idObjects, obj.id)).ToList();

            foreach (RefObjects refObj in query)
            {
                refObjController.DeleteRefObjects(refObj.id);
            }
        }
    }
}
