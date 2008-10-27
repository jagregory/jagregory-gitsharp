using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GitSharp
{
    public class Status : Command
    {
        public void Execute()
        {
            Config.Prepare(ConfigPresets);

            argc = parse_and_validate_options(argc, argv, builtin_status_usage, prefix);

            index_file = prepare_index(argc, argv, prefix);

            commitable = run_status(stdout, index_file, prefix, 0);

            rollback_index_files();

            return commitable ? 0 : 1;
        }

        private object ConfigPresets
        {
            get { return null; }
        }
    }

    public class Command
    {
        public Command()
        {
            Config = new Configuration();
        }

        protected Configuration Config { get; private set; }
    }

    public class Configuration
    {
        public void Prepare(object presets)
        {
            
        }
    }
}
