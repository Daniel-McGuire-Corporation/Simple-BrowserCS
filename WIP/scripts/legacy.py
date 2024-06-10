import argparse
import subprocess
import os

def get_verbosity(verbose):
    return '--verbosity detailed' if verbose else ''

def main():
    parser = argparse.ArgumentParser(description="Build Simple Browser")
    parser.add_argument("-t", "--type", default="Release", choices=["Release", "Debug"], help="Build configuration")
    parser.add_argument("-v", "--verbose", action="store_true", help="Display detailed build output")
    args = parser.parse_args()

    build_config = f"-c {args.type}"
    verbosity = get_verbosity(args.verbose)

    # Change the working directory to the project directory
    project_dir = os.path.abspath(os.path.join("..", "..", "src", "windows-alpha"))
    os.chdir(project_dir)

    # Construct your build command here
    dotnet_build_command = f"dotnet build Browser.csproj --nologo {build_config} -o bin/{args.type}/net8.0-windows10.0.22000.0 {verbosity}"

    print("\nCompiling Simple Browser")
    subprocess.run(dotnet_build_command, shell=True)

    print("\nCompiled!")

if __name__ == "__main__":
    main()
