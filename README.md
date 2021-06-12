# NDI-SubTitle

A Tool Using NDI To Make SubTitle In Live Production


## Develpoing
- Use openTK to show subtitles directly via other screen
- almost done!

## Download
- [Release Page](https://github.com/luvletter1205/NDI-SubTitle/releases)


## Features
- use NDI to output, containing Alpha channel.<br>
So you don't need to use Linear Key OR Luma Key if you send NDI to Wirecast or any other software.
- Support **Fade**, **Cut**, Also **Fade Clear** and **Cut Clear**
- Display **Two Lines** in the same time
- ~~Support Directly outputing to switcher such as ATEM~~ (NOT implementation)


## Input File Format
- Only Support **txt** Format
- Separate two lines into a group(SubTitle), They will show meanwhile
- 依次分割第1,2行、3,4行为一组，以此类推
- 中间的空格不删


## TODO
- ~~Add Config File~~
- Remember Last Open
- Direct Output via Unity or DirectX
