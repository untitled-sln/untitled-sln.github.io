using Markdig.Extensions.Tables;
using Markdig.Syntax;
using Markdig.Syntax.Inlines;
using Microsoft.AspNetCore.Components.Rendering;
using Block = Markdig.Syntax.Block;

namespace BlogProjBlazor.BlogPage;

public partial class BlogPageCode
{
    protected override void RenderBlock(RenderTreeBuilder builder, Block block)
    {
        int seq=0;
        switch (block)
        {
            case MarkdownDocument document:
                break;

            case ListBlock list:
                break;

            case ListItemBlock listItem:
                break;

            case QuoteBlock quote:
                break;

            case LinkReferenceDefinition linkRef:
                break;

            case ParagraphBlock paragraph:
                builder.OpenElement(0, "p");
                foreach (var il in paragraph.Inline)
                {
                    RenderInline(builder, il);
                }
                builder.CloseElement();
                break;
            case HeadingBlock heading:
                builder.OpenElement(seq, $"h{heading.Level}");
                foreach (var i in heading.Inline)
                {
                    RenderInline(builder, i);
                }
                builder.CloseElement();
                break;
            // case FencedCodeBlock fencedCode:
            //     break;

            case CodeBlock codeBlock:
                // 1. 判断是否为围栏式代码块
                string? language = null;
                if (codeBlock is FencedCodeBlock fenced)
                {
                    language = fenced.Info;  // 从 Info 获取语言
                }
            
                // 2. 获取代码内容（逐行拼接）
                string codeContent = string.Join("\n", 
                    codeBlock.CodeBlockLines.Select(line => line.ToString()));
            
                // 3. 渲染 HTML
                builder.OpenElement(seq++, "pre");
                builder.OpenElement(seq++, "code");
            
                if (!string.IsNullOrEmpty(language))
                {
                    builder.AddAttribute(seq++, "class", $"language-{language}");
                }
            
                builder.AddContent(seq++, codeContent);
            
                builder.CloseElement(); // code
                builder.CloseElement(); // pre
                break;
        

            case HtmlBlock html:
                break;

            case ThematicBreakBlock hr:
                builder.OpenElement(0, "hr");
                builder.CloseElement();
                break;
            case EmptyBlock empty:
                break;

            case BlankLineBlock blank:
                break;
            case Table table:
                builder.OpenElement(seq++, "table");
                builder.AddAttribute(seq++, "class", "ctable");
                foreach (var childRow in table)
                {
                    if (childRow is TableRow tableRow)
                    {
                        builder.OpenElement(seq++, "tr");
                        foreach (var childCell in tableRow)
                        {
                            if (childCell is TableCell tableCell)
                            {
                                builder.OpenElement(seq++, "th");
                                foreach (var cellChild in tableCell)
                                {
                                    RenderBlock(builder, cellChild);
                                }
                                builder.CloseElement();
                            }
                        }
                        builder.CloseElement();
                    }
                }
                builder.CloseElement();
                break;

            default:
                break;
        }
    }

    protected override void RenderInline(RenderTreeBuilder builder, Inline inline)
    {
        switch (inline)
        {
            case ContainerInline container:
                throw new Exception("ContainerInline应该被预处理");
            case LiteralInline literal:
                builder.OpenElement(0, "p");
                builder.AddContent(0,literal.Content+"喵");
                builder.CloseElement();
                break;
        }
    }
}