using System;
using System.Collections.Generic;
using NSubstitute;
using Search.DatabaseAndStoring;
using Search.Dependencies;
using Search.IO;
using Xunit;

namespace SearchTest
{
    [Collection("Test Collection 1")]
    public static class TestEssentials
    {
        public static readonly string Ls = Environment.NewLine;
        
        public static Data MakeData(string word, HashSet<string> fileNames)
        {
            return new Data(word, fileNames);
        }

        public static string GetStem(string word)
        {
            return Manager.Stemmer.Stem(word);
        }
        
        public static void MockFolderReaderForDataBase(IReader reader)
        {
            reader.Read("TestDataBase").Returns(new Dictionary<string, string>()
            {
                {
                    "4", "Mir rafte dubai vase nakhle talaii !!"
                },

                {
                    "3", $"man sag mikham{Ls}" +
                         $"sag khoshgel -  !!! mio !!!{Ls}"
                },
                {
                    "1", $"Hello Dear,{Ls}" +
                         $"I am Mohammad.{Ls}"
                }
            });
        }

        public static void MockFolderReaderForDataBase2(IReader reader)
        {
            reader.Read("TestDataBase2").Returns(new Dictionary<string, string>()
            {
                {
                    "gorbe", "sag sag sag sag sag sag sag sag asb"
                },
                {
                    "sag", @"


...







abbas, taghi mamooli, dubai"
                },
                {
                    "mohammad", @"
...

mohammad rafte gol bechine ,, ghaboole ? are are are ghaboole 


********



********






        :::   :::   ::::::::::: ::::::::: 
      :+:+: :+:+:      :+:     :+:    :+: 
    +:+ +:+:+ +:+     +:+     +:+    +:+  
   +#+  +:+  +#+     +#+     +#++:++#:    
  +#+       +#+     +#+     +#+    +#+    
 #+#       #+#     #+#     #+#    #+#     
###       ### ########### ###    ###      



********** 


          _____                    _____                    _____                    _____                    _____  
         /\    \                  /\    \                  /\    \                  /\    \                  /\    \ 
        /::\____\                /::\    \                /::\____\                /::\    \                /::\____\
       /::::|   |               /::::\    \              /::::|   |               /::::\    \              /:::/    /
      /:::::|   |              /::::::\    \            /:::::|   |              /::::::\    \            /:::/    / 
     /::::::|   |             /:::/\:::\    \          /::::::|   |             /:::/\:::\    \          /:::/    /  
    /:::/|::|   |            /:::/__\:::\    \        /:::/|::|   |            /:::/__\:::\    \        /:::/    /   
   /:::/ |::|   |           /::::\   \:::\    \      /:::/ |::|   |           /::::\   \:::\    \      /:::/    /    
  /:::/  |::|___|______    /::::::\   \:::\    \    /:::/  |::|___|______    /::::::\   \:::\    \    /:::/    /     
 /:::/   |::::::::\    \  /:::/\:::\   \:::\    \  /:::/   |::::::::\    \  /:::/\:::\   \:::\    \  /:::/    /      
/:::/    |:::::::::\____\/:::/  \:::\   \:::\____\/:::/    |:::::::::\____\/:::/  \:::\   \:::\____\/:::/____/       
\::/    / ~~~~~/:::/    /\::/    \:::\  /:::/    /\::/    / ~~~~~/:::/    /\::/    \:::\  /:::/    /\:::\    \       
 \/____/      /:::/    /  \/____/ \:::\/:::/    /  \/____/      /:::/    /  \/____/ \:::\/:::/    /  \:::\    \      
             /:::/    /            \::::::/    /               /:::/    /            \::::::/    /    \:::\    \     
            /:::/    /              \::::/    /               /:::/    /              \::::/    /      \:::\    \    
           /:::/    /               /:::/    /               /:::/    /               /:::/    /        \:::\    \   
          /:::/    /               /:::/    /               /:::/    /               /:::/    /          \:::\    \  
         /:::/    /               /:::/    /               /:::/    /               /:::/    /            \:::\    \ 
        /:::/    /               /:::/    /               /:::/    /               /:::/    /              \:::\____\
        \::/    /                \::/    /                \::/    /                \::/    /                \::/    /
         \/____/                  \/____/                  \/____/                  \/____/                  \/____/ 
                                                                                                                     



:::        ::::::::::: ::::::::  ::::    ::::      :::     
:+:            :+:    :+:    :+: +:+:+: :+:+:+   :+: :+:   
+:+            +:+    +:+        +:+ +:+:+ +:+  +:+   +:+  
+#+            +#+    :#:        +#+  +:+  +#+ +#++:++#++: 
+#+            +#+    +#+   +#+# +#+       +#+ +#+     +#+ 
#+#            #+#    #+#    #+# #+#       #+# #+#     #+# 
########## ########### ########  ###       ### ###     ### "
                }
            });
        }
    }
}