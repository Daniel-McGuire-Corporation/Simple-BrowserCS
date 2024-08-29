#!/bin/bash

# Default corner radius percentage and output directory
default_radius_percent=22
default_output_dir="./icons"

# Parse the command-line arguments for the radius percentage and output directory
while getopts ":p:o:" opt; do
  case $opt in
    p)
      radius_percent=$OPTARG
      ;;
    o)
      output_dir=$OPTARG
      ;;
    \?)
      echo "Invalid option: -$OPTARG" >&2
      exit 1
      ;;
    :)
      echo "Option -$OPTARG requires an argument." >&2
      exit 1
      ;;
  esac
done

# Use the default values if not specified
radius_percent=${radius_percent:-$default_radius_percent}
output_dir=${output_dir:-$default_output_dir}

# Create the output directory if it does not exist
mkdir -p "$output_dir"

# Iterate over each image file in the current directory
for file in *.png; do
    # Check if the file exists
    if [ -f "$file" ]; then
        # Extract the size from the file name (format: size.png)
        size=$(basename "$file" .png)

        # Check if the size is a valid number
        if [[ "$size" =~ ^[0-9]+$ ]]; then
            # Define the dimensions
            dimensions="${size}x${size}"

            # Calculate the corner radius based on the specified percentage
            radius=$((size * radius_percent / 100))

            # Output file path
            output="$output_dir/$file"

            # Create a unique name for the temporary mask file
            mask_file="rounded_mask_${size}.png"

            # Create a rounded corner mask with the calculated radius
            if ! magick -size $dimensions xc:none -fill white -draw "roundrectangle 0,0 $size,$size $radius,$radius" "$mask_file"; then
                echo "Failed to create mask for $file. Skipping..."
                continue
            fi

            # Apply the rounded mask to the image
            if ! magick "$file" "$mask_file" -alpha set -compose DstIn -composite "$output"; then
                echo "Failed to apply mask to $file. Skipping..."
                rm "$mask_file"
                continue
            fi

            # Remove the temporary mask file
            rm "$mask_file"
        else
            echo "Invalid size in filename for $file. Skipping..."
        fi
    fi
done

echo "Processing complete. Rounded images are saved in the '$output_dir' folder."
