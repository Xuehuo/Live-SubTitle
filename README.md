# NDI-SubTitle

A Tool Using NDI To Make SubTitle In Live Production



## Features
- use NDI to output, containing Alpha channel.<br>
So you don't need to use Linear Key OR Luma Key if you send NDI to Wirecast or any other software.
- Support **Fade**, **Cut**, Also **Fade Clear** and **Cut Clear**
- Display **Two Lines** in the same time
- ~~Support Directly outputing to switcher such as ATEM~~ (NOT implementation)



## Input File Format
- Only Support **txt** Format
- Separate two lines into a group(SubTitle), They will show meanwhile
- **Blank Line(s)** between two lines will be a **Empty** SubTitle, You can use this to separate two section


