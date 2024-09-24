
self.addEventListener('install', function (e) {
    console.log('[Service Worker] Install');
    
    e.waitUntil(
        caches.keys().then((cacheNames) => {
            return Promise.all(
                cacheNames.map((cacheName) => {
                    console.log('[Service Worker] Deleting cache:', cacheName);
                    return caches.delete(cacheName);
                })
            );
        }).then(() => {
            // Optionally, skip waiting to immediately activate the new service worker
            return self.skipWaiting();
        })
    );

});

