To set up a local dev environment of Andromeda, first run the .msi installers located in [prerequisites](https://github.com/m104software/andromeda/tree/master/prerequisites).

Next, open Andromeda.sln, locate /Config directories and add a file to each, based on custom.config, containing your local settings and named after your machine, i.e., _machine-name_.config.

Verify that you have a SQL Server database at the location defined in your _machine-name_.config file. Start the Azure Storage Emulator. Run the unit tests. You are now good to go.

See the [wiki](https://github.com/m104software/andromeda/wiki) for further information on Andromeda.