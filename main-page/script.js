const trackingTabs = document.querySelectorAll('.tracking-section__tab');
const trackingContent = document.querySelector('.tracking-section__tracking');
const deliveryContent = document.querySelector('.tracking-section__delivery');

trackingTabs.forEach(tab => {
  tab.addEventListener('click', () => {
    const tabId = tab.getAttribute('data-tab');
    trackingTabs.forEach(t => t.classList.remove('tracking-section__tab--active'));
    tab.classList.add('tracking-section__tab--active');
    if (tabId === 'tracking') {
      trackingContent.classList.remove('hidden');
      deliveryContent.classList.add('hidden');
    } else if (tabId === 'request-delivery') {
      deliveryContent.classList.remove('hidden');
      trackingContent.classList.add('hidden');
    }
  });
});

const headerTabs = document.querySelectorAll('.header__tab');
const homeSection = document.querySelector('.home-section');
const aboutSection = document.querySelector('.about-section');

headerTabs.forEach(tab => {
  tab.addEventListener('click', () => {
    const tabId = tab.getAttribute('data-tab');
    headerTabs.forEach(t => t.classList.remove('header__tab--active'));
    tab.classList.add('header__tab--active');
    if (tabId === 'home') {
      homeSection.classList.remove('hidden');
      aboutSection.classList.add('hidden');
    } else if (tabId === 'about') {
      aboutSection.classList.remove('hidden');
      homeSection.classList.add('hidden');
    }
  });
});
