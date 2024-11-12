# Unity Component Copier

A Unity Editor tool that copies components between GameObjects with matching names, regardless of their hierarchy structure. Perfect for duplicating component setups across different character prefabs or scene objects.

## Installation

1. Create an "Editor" folder in your Unity project's Assets folder (if it doesn't exist)
2. Place `ComponentCopier.cs` inside the Editor folder
3. Unity will automatically compile the editor script

## Usage

### Basic Usage
1. In Unity, go to `Tools > Component Copier`
2. In the Component Copier window:
   - Select your source object (the one with components you want to copy)
   - Select your target object (where you want the components to be copied)
   - Click "Copy Components"

### Options
- **Pick From Scene**: Toggle this to allow selecting objects from the current scene
- **Show Debug Info**: Toggle to see detailed logging of what's being copied

### How It Works
- The tool matches objects by name, not hierarchy
- Components are copied from source to target for all matching names
- Skips Transform components to preserve hierarchy
- Automatically saves prefab changes
- Shows warnings for unmatched objects



## Features

- ✓ Copies components between matching named objects
- ✓ Works with both scene objects and prefabs
- ✓ Preserves all component settings and references
- ✓ Detailed debug logging
- ✓ Handles missing or unmatched objects gracefully
- ✓ No hierarchy structure requirements

## Best Practices

1. **Backup First**: Always backup your project before mass-copying components
2. **Check Names**: Ensure objects you want to copy between have matching names
3. **Use Debug**: Enable "Show Debug Info" to verify correct copying
4. **Scene Objects**: Remember to save your scene after copying to scene objects
5. **Prefabs**: Changes are auto-saved for prefabs

## Common Use Cases

1. **Character Variants**: Copy components between different character models
2. **Prefab Updates**: Update multiple similar prefabs with new components
3. **Scene Setup**: Copy complex component setups between scene objects
4. **Ragdoll Setup**: Copy physics components between character models

## Limitations

- Only copies components to objects with exactly matching names
- Cannot copy components that require specific setup steps
- Transform components are intentionally skipped

## Troubleshooting

### No Components Copied
- Check if object names match exactly (case-sensitive)
- Verify source objects have components to copy
- Enable "Show Debug Info" for detailed logging

### Missing References
- Components with scene references may need manual reconnection
- Prefab references usually maintain their connections

### Error Messages
- "No matching object found": Target is missing an object with that name
- "Failed to copy component": Component requires special setup

## Contributing

Feel free to submit issues and enhancement requests!

## License

This project is licensed under the MIT License - see the LICENSE file for details
