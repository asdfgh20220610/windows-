#AI 辅助制作#
##提示词：##
创建一个Windows桌面应用程序，使用C#和WPF开发，目的是设计一个记单词的软件。该软件在启动后会自动打开一个始终置顶的小窗口，展示若干英语单词。点击这些单词会显示它们的中文意思，窗口底部包含进度条、下一页按钮和设置选项。
设计一个简洁的WPF界面，包含以下元素：
- 一个小窗口，设置为始终置顶。
- 在窗口中央显示5-10个英语单词，使用ListBox或StackPanel布局，单词以按钮形式呈现。
- 每个单词点击时会显示对应的中文翻译。
- 底部包含一个ProgressBar，显示学习进度，和一个“下一页”按钮，用于翻到下一组单词。
- 窗口应尽量简洁，符合苹果风格的UI设计，背景色简洁，控件之间有足够的间距，文字清晰易读。
编写C#代码设置WPF窗口的Topmost属性，使得应用程序启动后始终保持在屏幕最上层。
设计一个数据结构（如Dictionary或List）来存储英语单词和对应的中文翻译。每个英语单词显示为一个Button，点击时会弹出对应的中文翻译，使用消息框（MessageBox）或ToolTip显示中文翻译。
添加一个ProgressBar控件，显示学习进度。根据单词学习的进度动态更新进度条的值。每次用户点击‘下一页’按钮时，切换到下一组单词并更新进度条的值。进度条的最大值为总单词数量。
设计一个选项菜单，可以包括如下功能：
- 更改单词显示的数量（例如每页显示5个或10个单词）。
- 设置字体大小和窗口背景色等界面样式。
- 保存设置并在程序重启后加载用户偏好的配置。
使用SQLite数据库或JSON文件存储单词和它们的中文翻译。编写代码实现加载文件数据并动态展示单词。每组单词的顺序可以随机化，以防止用户记忆模式的偏差。
确保程序在处理大量单词数据时依然保持良好的性能。避免在加载和展示单词时出现卡顿。可以使用异步操作来加载数据，避免阻塞UI线程。
确保UI界面简单、直观，使用大号字体显示单词，颜色和布局应避免过于复杂。进度条、按钮和文本的大小要适应不同分辨率，确保可操作性。点击按钮后的反馈要及时，例如通过颜色变化或者动画效果显示用户的操作。
组织项目代码时，采用MVVM（Model-View-ViewModel）架构，确保代码的解耦性和可维护性。界面逻辑（View）与业务逻辑（ViewModel）分开，数据存储和处理（Model）与UI部分隔离。
编写单元测试，测试各个模块功能的正确性。特别是单词点击事件、分页功能、进度条更新等。确保程序在不同情况下（如无网络、数据库未加载等）都能正常工作。

##待完成的任务：##
1.透明度可调节
2.单词本可自主上传
3.背景图片可自定义
4.。。。
