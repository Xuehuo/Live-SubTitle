# NDI-SubTitle

A Tool Using NDI To Make SubTitle In Live Production


## Develpoing
- Use openTK to show subtitles directly via other screen
- almost done!

## Download
- [Release Page](https://github.com/luvletter1205/NDI-SubTitle/releases)


## Features
- Support NDI Output, containing Alpha channel.
- Support FullScreen Output like vMix
- Support **Fade**, **Cut**, Also **Fade Clear** and **Cut Clear**
- Display **Two Lines** in the same time

## User Guide

1. 启动后选择输出屏幕 确认分辨率并Lock
2. Import导入字幕txt，Load加载所有字幕
3. 在系统高级显示设置中调整输出显示器的帧率
4. Alt + Tab切换到 Full Screen 窗口后再切换回来（不然光标不见了）
5. 在 Render Control Panel 中调整字幕位置和大小，合适后Lock住
6. 使用空格和回车进行切换 


## Input File Format
- Only Support **txt** Format
- Separate two lines into a group(SubTitle), They will show meanwhile
- 依次分割第1,2行、3,4行为一组，以此类推
- 中间的空格不删


## TODO
- Remember Last Open
