namespace ActiveDiabetesAssistant.DAL.Entities.Vision;

public class OcrResponse
{
	public Result Result { get; set; }
}

public class Result
{
	public TextAnnotation TextAnnotation { get; set; }
	public int Page { get; set; }
}

public class TextAnnotation
{
	public int Width { get; set; }
	public int Height { get; set; }
	public List<Block> Blocks { get; set; }
	public List<object> Entities { get; set; }
	public List<object> Tables { get; set; }
	public string FullText { get; set; }
	public string Rotate { get; set; }
}

public class Block
{
	public BoundingBox BoundingBox { get; set; }
	public List<Line> Lines { get; set; }
	public List<Language> Languages { get; set; }
	public List<TextSegment> TextSegments { get; set; }
}

public class BoundingBox
{
	public List<Vertex> Vertices { get; set; }
}

public class Vertex
{
	public int X { get; set; }
	public int Y { get; set; }
}

public class Line
{
	public BoundingBox BoundingBox { get; set; }
	public string Text { get; set; }
	public List<Word> Words { get; set; }
	public List<TextSegment> TextSegments { get; set; }
	public string Orientation { get; set; }
}

public class Word
{
	public BoundingBox BoundingBox { get; set; }
	public string Text { get; set; }
	public int EntityIndex { get; set; }
	public List<TextSegment> TextSegments { get; set; }
}

public class TextSegment
{
	public int StartIndex { get; set; }
	public int Length { get; set; }
}

public class Language
{
	public string LanguageCode { get; set; }
}