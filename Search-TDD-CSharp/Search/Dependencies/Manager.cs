﻿using Search.IO;

namespace Search.Dependencies
{
    public class Manager
    {
        public static IReader FileReaderInstance = new FileReader();
        public static IReader FolderReaderInstance = new FolderReader();

    }
}