﻿using System;
using System.Collections.Generic;
using SharpYaml.Serialization;

namespace Elastic.Installer
{
    public sealed class PackageInfo
    {
        [YamlMember("description")]
        public string Description { get; set; } = "(add 'description' field to config.yaml)";

        [YamlMember("service")]
        public bool IsWindowsService { get; set; } = true;

        [YamlMember("mutable_dirs", SerializeMemberMode.Content)]
        public List<string> MutableDirs { get; }

        [YamlMember("upgrade_code")]
        public Guid UpgradeCode { get; set; }

        public PackageInfo()
        {
            MutableDirs = new List<string>();
        }
    }
}