import React, { useState, useEffect } from 'react';

export default function Map() {
  const [mapImage, setMapImage] = useState(null);
  const [windowSize, setWindowSize] = useState({
    width: window.innerWidth,
    height: window.innerHeight
  });

  useEffect(() => {
    // Получите изображение с сервера
    fetch('http://localhost:5147/getimage?Name=..%2Fassets%5C%5C7cf2b4a50c8ad52dbe506f428abd046d.png')
      .then(response => response.blob())
      .then(imageBlob => {
        // Преобразуйте полученный Blob в URL изображения
        const imageUrl = URL.createObjectURL(imageBlob);
        setMapImage(imageUrl);
      });

    // Очистите URL изображения при размонтировании компонента
    return () => {
      if (mapImage) {
        URL.revokeObjectURL(mapImage);
      }
    };
  }, []);

  useEffect(() => {
    const handleResize = () => {
      setWindowSize({
        width: window.innerWidth,
        height: window.innerHeight
      });
    };

    window.addEventListener('resize', handleResize);

    return () => {
      window.removeEventListener('resize', handleResize);
    };
  }, []);

  return (
    <div style={{ height: '1000px', width: '1000px', overflow: 'hidden' }}>
      {mapImage && (
        <img
          src={"http://localhost:5147/getimage?Name=..%2Fassets%5C%5C7cf2b4a50c8ad52dbe506f428abd046d.png"}
          alt="Map"
          style={{
            width: '100%',
            height: 'auto',
            maxHeight: '100%',
            maxWidth: '66.66%',
          }}
        />
      )}
    </div>
  );
}