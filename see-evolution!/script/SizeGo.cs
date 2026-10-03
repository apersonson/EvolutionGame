using Godot;
using System;

public partial class SizeGo : TextureRect
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Size = new Vector2(Size.X, 50f);
		Size = new Vector2(Size.Y*1.8f, Size.Y);
		string filepath = "user://Image/saved_drawing.png";
		if(FileAccess.FileExists(filepath))
		{
			// 1. 이미지 객체 생성 후 파일 로드
            Image image = Image.LoadFromFile(filepath);

            // 2. 이미지를 Texture2D로 변환하여 TextureRect에 적용
            Texture = ImageTexture.CreateFromImage(image);		
			}
	}
}
