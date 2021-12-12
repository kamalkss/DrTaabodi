const animOb = new IntersectionObserver(function (enteries, observer) {
    enteries.forEach(x => {
        if (x.target.id === 'about-me-image') {
            if (x.isIntersecting) {
                x.target.children[0].classList.add('animate__fadeInRight');
            } else {
                x.target.children[0].classList.remove('animate__fadeInRight');
            }
        }
        if (x.target.id === 'about-me-profile') {
            if (x.isIntersecting) {
                x.target.children[0].classList.add('animate__fadeInLeft');
            } else {
                x.target.children[0].classList.remove('animate__fadeInLeft');
            }
        }
    })
}, {threshold: .1});

animOb.observe(document.getElementById('about-me-image'));
animOb.observe(document.getElementById('about-me-profile'));

document.addEventListener('click', e => {
    if (e.target && e.target.classList && e.target.classList.contains('controller')) {
        const itemsContainer = e.target.closest('.horizontal-slider').querySelector('.items-container');
        const step = itemsContainer.children[0].clientWidth;

        const width = itemsContainer.scrollWidth - itemsContainer.clientWidth;
        const left = Math.abs(itemsContainer.scrollLeft);

        if (e.target.classList.contains('right')) {
            if (width <= left)
                itemsContainer.scrollTo(0, 0);
            else
                itemsContainer.scrollBy(-step, 0);
        } else {
            if (left <= 0)
                itemsContainer.scrollTo(-width, 0);
            else
                itemsContainer.scrollBy(step, 0);
        }
    }
})


