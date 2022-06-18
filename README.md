# slt
slt is kind of like sl, but instead of a steam locomotive it’s an [NS Sprinter
Light Train (SLT)](https://trains.chuniversiteit.nl/#slt).

## Installation

### macOS 10.12+ / Linux (x64, ARM)
Paste and execute the following command in a terminal window:

```
/bin/bash -c "$(curl -L https://raw.githubusercontent.com/chunfeilung/slt/main/install.sh)"
```

### Windows
> :warning: slt may not display properly in cmd.exe. Please use Windows Terminal
> for now.

Download the latest `slt-win-x64.exe` from the Releases page and rename it to
`slt.exe`. Place the executable in a directory that’s included in your `PATH`,
e.g. `C:\Windows\System32`.

### Other platforms
…are currently not supported.

## Usage

To view a line drawing of a Sprinter Light Train, execute `slt` with `-l`,
`--lines` or without any options.

```
slt
```

https://user-images.githubusercontent.com/10553406/173187939-e5ef42d4-0075-40b9-ab63-fa830b59cee4.mov

Alternatively, you can make `slt` show a grayscale train by providing the `-f`
or `--filled` option. This option can also be combined with the `-c` or
`--colored` option for a more colorful experience:

```
slt --filled --colored
```

https://user-images.githubusercontent.com/10553406/173187953-7e0933a5-2042-460c-8b91-01e5a5ee307f.mov

To make the train move faster or slower, provide the `--speed` or `-s` option
with a numeric value. The speed of the train will be multiplied by the provided
value.

```
slt --speed 5
```

https://user-images.githubusercontent.com/10553406/173188082-302cf14e-e49f-414a-adaf-af715fa9128c.mov
