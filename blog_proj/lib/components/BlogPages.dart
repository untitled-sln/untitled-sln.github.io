import 'dart:io';

import 'package:jaspr/dom.dart';
import 'package:jaspr/jaspr.dart';



class BlogPages extends StatelessComponent {

  late String mdContent;
  late List<String> mdPaths;
  late String buildTime;

  (String mdContent,List<String> mdPaths,String buildTime) BuildContent(String mdPath){
      final file = File(mdPath);
      var content = file.readAsStringSync();
      final buildTime = DateTime.now().toString();
      return (content,mdPath.split('/'),buildTime);
  }
  Element ToElement()

  BlogPages(String mdPath) {
    var (content,mdPaths,buildTime) = BuildContent(mdPath);
    this.mdContent = content;
    this.mdPaths = mdPaths;
    this.buildTime = buildTime;
  }

  @override
  Component build(BuildContext context) =>
      div(classes: 'blog-pages', []);

  @css
  static List<StyleRule> get styles => [
    css('.blog-pages', [
      css('&').styles(
        display: .flex,
        flexDirection: .column,
        justifyContent: .center,
        alignItems: .center,
        flex: Flex(grow: 1),
      ),
    ]),
  ];
}
