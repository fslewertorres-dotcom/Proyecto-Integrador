Add-Type -AssemblyName System.Drawing
$d = $args[0]
$img = [System.Drawing.Image]::FromFile("$d\FrVias.png")
$c = New-Object System.Drawing.Bitmap 500, 640
$g = [System.Drawing.Graphics]::FromImage($c)
$g.DrawImage($img, (New-Object System.Drawing.Rectangle 0,0,500,640), (New-Object System.Drawing.Rectangle 1140,240,500,640), [System.Drawing.GraphicsUnit]::Pixel)
$c.Save("$d\vias_form.png")
