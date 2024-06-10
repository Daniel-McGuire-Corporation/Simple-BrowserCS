import argparse
import subprocess

def get_verbosity(verbose):
    return '--verbosity detailed' if verbose else ''

def main():
    parser = argparse.ArgumentParser(description="Build Simple Browser")
    parser.add_argument("-t", "--type", default="Release", choices=["Release", "Debug"], help="Build configuration")
    parser.add_argument("-v", "--verbose", action="store_true", help="Display detailed build output")
    args = parser.parse_args()

    build_config = f"-c {args.type}"
    verbosity = get_verbosity(args.verbose)

    # Construct your build command here
    dotnet_build_command = f"dotnet build Simple-Browser.csproj --nologo {build_config} -o bin/{args.type}/net8.0-windows10.0.22000.0 {verbosity}"

    print("\nCompiling Simple Browser")
    subprocess.run(dotnet_build_command, shell=True)

    print("\nInstaller Compiled!")
    continue_install = input("Do you want to install Simple Browser? [y/n]: ")
    if continue_install.lower() == 'n':
        exit()

    # Add installation logic here

if __name__ == "__main__":
    main()
