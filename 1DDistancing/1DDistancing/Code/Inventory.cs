using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _1DDistancing.Code
{
    class Inventory
    {
          public static List<Tag> StartTagInventory(ComPort port)
          {
              List<Tag> Tags = new List<Tag>();
              int TagCount;
              port.SendCommand(Constants.InventoryRSSI.SendID, Constants.InventoryRSSI.Type.Start);
              byte[] Back = port.ReadPacket();
              if (!(Back[0] == Constants.InventoryRSSI.RecieveID))
                    throw new Exception("Error Starting RSSI Inventory!");
              Tags.Add(new Tag(Back));
              TagCount = (int)Back[2] -1; //Minus one because we have already read the first tag
              int i = 0;
              while (i < TagCount)
              {
                  Tags.Add(NextTagInventory(port));
                  i++;
              }

              return Tags;
          }

          private static Tag NextTagInventory(ComPort port)
          {
              //port.SendCommand(Constants.InventoryRSSI.SendID, Constants.InventoryRSSI.Type.Start);
              byte[] Back = port.ReadPacket();
              if (!(Back[0] == Constants.InventoryRSSI.RecieveID))
                    throw new Exception("Error Getting next tag");
              return new Tag(Back);
          }



    }
}
