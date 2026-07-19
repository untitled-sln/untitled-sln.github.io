import 'package:jaspr/dom.dart';
import 'package:jaspr/jaspr.dart';

// The main component of your application.
//
// By using multi-page routing, this component will only be built on the server during pre-rendering and
// **not** executed on the client. Instead only the nested [Home] and [About] components will be mounted on the client.
class App extends StatelessComponent {
  const App({super.key});

  @override
  Component build(BuildContext context) {
    // This method is rerun every time the component is rebuilt.

    // Renders a <div class="main"> html element with children.
    return body(classes: 'layout', [
      header([.text("头部")]),
      main_(id: "main",[
        aside(classes: 'sidebar', [
          button(classes: 'toggle', [.text('☰')]),
          h2([.text('Jaspr Demo')]),
          ul([
            li([.text('🏠 首页')]),
            li([.text('📁 文件')]),
            li([.text('⚙ 设置')]),
          ]),
        ]),
        section(classes: 'content', [
          h1([.text('主页')]),
          p([.text('Hello Jaspr')]),
        ]),
      ]),
    ]);
  }

  // Defines the CSS styles for this component.
  //
  // By using the @css annotation, these will be rendered automatically to CSS and included in your page.
  // Must be a variable or getter of type [List<StyleRule>].
  @css
  static List<StyleRule> get styles => [
    css('.layout', [
      // The '&' refers to the parent selector of a nested style rules.
      css('&').styles(
        display: .flex,
        // height: 100.vh,
        // flexDirection: .column,
        // flexWrap: .wrap,
      ),
      css('section').styles(
        display: .flex,
        flexDirection: .column,
        justifyContent: .center,
        alignItems: .center,
        flex: Flex(grow: 1),
      ),
    ]),
    css('main').styles(
      display: .flex,
      flex: Flex(grow: 1),
    ),
  ];
}
