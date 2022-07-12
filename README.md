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

https://user-images.githubusercontent.com/10553406/178531829-434fb0a6-05e1-4a83-acd9-ed7990dac009.mp4

Alternatively, you can make `slt` show a grayscale train by providing the `-f`
or `--filled` option. This option can also be combined with the `-c` or
`--colored` option for a more colorful experience:

```
slt --filled --colored
```

https://user-images.githubusercontent.com/10553406/178531924-d37638bd-c21f-4c5b-850a-1c369df53daa.mp4

To make the train move faster or slower, provide the `--speed` or `-s` option
with a numeric value. The speed of the train will be multiplied by the provided
value.

```
slt --speed 5
```

https://user-images.githubusercontent.com/10553406/178531977-54f0bdce-e3a3-468a-b952-23063b310758.mp4


A complete list of supported options can be displayed by passing the `--help`
option:

```
slt --help
```
