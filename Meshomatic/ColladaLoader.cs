using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Schema;


namespace Meshomatic {
	public class ColladaLoader {
		public ColladaLoader () {
		}
		
		public MeshData LoadFile(string file) {
			using(FileStream s = File.Open(file, FileMode.Open)) {
				return LoadStream(s);
			}
		}
		
		private static void ValidationEventHandler(object sender, ValidationEventArgs args) {
			Console.WriteLine("sender {0}, args {1}", sender, args);
		}
		
		public MeshData LoadStream(Stream stream) {
			Console.WriteLine("Foo1");
			XmlReaderSettings settings = new XmlReaderSettings();
			Console.WriteLine("Foo2");
			settings.Schemas.Add("http://www.collada.org/2005/11/COLLADASchema", "collada_schema_1_4");
			Console.WriteLine("Foo3");
			settings.ValidationType = ValidationType.Schema;
			Console.WriteLine("Foo4");
			XmlReader reader = XmlReader.Create(stream, settings);
			Console.WriteLine("Foo5");
			XmlDocument doc = new XmlDocument();
			Console.WriteLine("Foo6");
			doc.Load(reader);
			Console.WriteLine("Foo7");
			ValidationEventHandler eventHandler = new ValidationEventHandler(ValidationEventHandler);
			Console.WriteLine("Foo8");
			doc.Validate(eventHandler);
			Console.WriteLine("Foo9");


			
			/*
			Console.WriteLine("Foo1");
			XmlDocument asset = new XmlDocument();
			Console.WriteLine("Foo2");
			XmlTextReader schemaReader = new XmlTextReader("collada_schema_1_4");
			Console.WriteLine("Foo3");
			XmlSchema schema = XmlSchema.Read(schemaReader, ValidationCallback);
			Console.WriteLine("Foo4");
			asset.Schemas.Add(schema);
			Console.WriteLine("Foo5");
			asset.Load(stream);
			Console.WriteLine("Foo6");
			asset.Validate(ValidationCallback);
			Console.WriteLine("Foo7");
			*/
			return null;
			/*
			XmlReader textReader = new XmlTextReader(stream);
			 textReader.Read();

            // If the node has value

            while (textReader.Read())
            {
                // Move to fist element
                textReader.MoveToElement();
                Console.WriteLine("XmlTextReader Properties Test");
                Console.WriteLine("===================");
                // Read this element's properties and display them on console
                Console.WriteLine("Name:" + textReader.Name);
                Console.WriteLine("Base URI:" + textReader.BaseURI);
                Console.WriteLine("Local Name:" + textReader.LocalName);
                Console.WriteLine("Attribute Count:" + textReader.AttributeCount.ToString());
                Console.WriteLine("Depth:" + textReader.Depth.ToString());
                //Console.WriteLine("Line Number:" + textReader.LineNumber.ToString());
                Console.WriteLine("Node Type:" + textReader.NodeType.ToString());
                Console.WriteLine("Attribute Count:" + textReader.Value.ToString());
            }
			
			XmlDocument d = new XmlDocument();
			XmlSchema s = new XmlSchema();
			
			return null;
			*/
		}
	}
}
