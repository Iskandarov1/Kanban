using Ilmhub.Spaces.Client.Models;

namespace Ilmhub.Spaces.Client.Services;

public class LeadDataService(ICourseDataService courseDataService) : ILeadDataService
{

	public Task<List<Lead>> GetAllLeadsAsync(CancellationToken cancellationToken = default) =>
		Task.FromResult(SampleLeads);

	public Task<Lead?> GetLeadByIdOrDefaultAsync(int id, CancellationToken cancellationToken = default) =>
		Task.FromResult(SampleLeads.FirstOrDefault(l => l.Id == id));

	public Task<Lead> CreateLeadAsync(Lead lead, CancellationToken cancellationToken = default)
	{
		lead.Id = SampleLeads.Max(l => l.Id) + 1;
		lead.CreatedAt = DateTime.Now;
		lead.ModifiedAt = DateTime.Now;
		SampleLeads.Add(lead);
		return Task.FromResult(lead);
	}

	public Task<Lead?> UpdateLeadOrDefaultAsync(Lead lead, CancellationToken cancellationToken = default)
	{
		var existingLead = SampleLeads.FirstOrDefault(l => l.Id == lead.Id);
		if (existingLead != null)
		{
			existingLead.Name = lead.Name;
			existingLead.Phone = lead.Phone;
			existingLead.Status = lead.Status;
			existingLead.Source = lead.Source;
			existingLead.Interest = lead.Interest;
			existingLead.ModifiedAt = DateTime.Now;
		}
		return Task.FromResult(existingLead);
	}

	public Task<bool> DeleteLeadAsync(int id, CancellationToken cancellationToken = default)
	{
		var lead = SampleLeads.FirstOrDefault(l => l.Id == id);
		if (lead != null)
		{
			SampleLeads.Remove(lead);
			return Task.FromResult(true);
		}
		return Task.FromResult(false);
	}

    private readonly List<Lead> SampleLeads =
    [
        new() { Id = 1, Name = "Aziz Yuldashev", Email = "aziz.yuldashev@example.com", Phone = "+998 90 123 45 67", Status = LeadStatus.Created, Source = LeadSource.Website, CreatedAt = DateTime.Now.AddDays(-30), ModifiedAt = DateTime.Now.AddDays(-30), Interest = courseDataService.GetAllCoursesAsync().Result[0], Notes = "Toshkentdan. Web dasturlash kursiga qiziqish bildirdi." },
        new() { Id = 2, Name = "Malika Karimova", Email = "malika.karimova@example.com", Phone = "+998 91 234 56 78", Status = LeadStatus.Contacted, Source = LeadSource.Referral, CreatedAt = DateTime.Now.AddDays(-25), ModifiedAt = DateTime.Now.AddDays(-25), Interest = courseDataService.GetAllCoursesAsync().Result[1], Notes = "Samarqanddan. Do'sti tavsiya qilgan. Ingliz tili kursiga qiziqmoqda." },
        new() { Id = 3, Name = "Rustam Aliyev", Email = "rustam.aliyev@example.com", Phone = "+998 92 345 67 89", Status = LeadStatus.NoContact, Source = LeadSource.SocialMedia, CreatedAt = DateTime.Now.AddDays(-20), ModifiedAt = DateTime.Now.AddDays(-20), Interest = courseDataService.GetAllCoursesAsync().Result[2], Notes = "Buxorodan. Instagram orqali topgan. Data Science kursiga qiziqish bildirdi." },
        new() { Id = 4, Name = "Nilufar Rahimova", Email = "nilufar.rahimova@example.com", Phone = "+998 93 456 78 90", Status = LeadStatus.Lost, Source = LeadSource.Advertisement, CreatedAt = DateTime.Now.AddDays(-15), ModifiedAt = DateTime.Now.AddDays(-15), Interest = courseDataService.GetAllCoursesAsync().Result[3], Notes = "Farg'onadan. Reklama orqali topgan, lekin hozircha qiziqish yo'q." },
        new() { Id = 5, Name = "Jahongir Umarov", Email = "jahongir.umarov@example.com", Phone = "+998 94 567 89 01", Status = LeadStatus.Acquired, Source = LeadSource.Website, CreatedAt = DateTime.Now.AddDays(-10), ModifiedAt = DateTime.Now.AddDays(-10), Interest = courseDataService.GetAllCoursesAsync().Result[4], Notes = "Namangandan. Veb-saytdan ro'yxatdan o'tgan. Mobil dasturlash kursiga yozildi." },
        new() { Id = 6, Name = "Gulnora Saidova", Email = "gulnora.saidova@example.com", Phone = "+998 95 678 90 12", Status = LeadStatus.Created, Source = LeadSource.SocialMedia, CreatedAt = DateTime.Now.AddDays(-8), ModifiedAt = DateTime.Now.AddDays(-8), Interest = courseDataService.GetAllCoursesAsync().Result[5], Notes = "Andijandan. Facebook orqali topgan. Kiber xavfsizlik kursiga qiziqmoqda." },
        new() { Id = 7, Name = "Botir Xolmatov", Email = "botir.xolmatov@example.com", Phone = "+998 96 789 01 23", Status = LeadStatus.Contacted, Source = LeadSource.Referral, CreatedAt = DateTime.Now.AddDays(-7), ModifiedAt = DateTime.Now.AddDays(-7), Interest = courseDataService.GetAllCoursesAsync().Result[6], Notes = "Qo'qondan. Do'sti tavsiya qilgan. AI kursiga qiziqish bildirdi." },
        new() { Id = 8, Name = "Zarina Umarova", Email = "zarina.umarova@example.com", Phone = "+998 97 890 12 34", Status = LeadStatus.NoContact, Source = LeadSource.Website, CreatedAt = DateTime.Now.AddDays(-6), ModifiedAt = DateTime.Now.AddDays(-6), Interest = courseDataService.GetAllCoursesAsync().Result[7], Notes = "Xivadan. Veb-saytdan topgan. Database Management kursiga qiziqmoqda." },
        new() { Id = 9, Name = "Sardor Alimov", Email = "sardor.alimov@example.com", Phone = "+998 98 901 23 45", Status = LeadStatus.Lost, Source = LeadSource.Advertisement, CreatedAt = DateTime.Now.AddDays(-5), ModifiedAt = DateTime.Now.AddDays(-5), Interest = courseDataService.GetAllCoursesAsync().Result[8], Notes = "Jizzaxdan. Reklama orqali topgan, lekin vaqt topa olmayapti." },
        new() { Id = 10, Name = "Dilnoza Karimova", Email = "dilnoza.karimova@example.com", Phone = "+998 99 012 34 56", Status = LeadStatus.Acquired, Source = LeadSource.SocialMedia, CreatedAt = DateTime.Now.AddDays(-4), ModifiedAt = DateTime.Now.AddDays(-4), Interest = courseDataService.GetAllCoursesAsync().Result[9], Notes = "Navoiydan. Instagram orqali topgan. DevOps kursiga yozildi." },
        new() { Id = 11, Name = "Akmal Rahmonov", Email = "akmal.rahmonov@example.com", Phone = "+998 90 234 56 78", Status = LeadStatus.Created, Source = LeadSource.Website, CreatedAt = DateTime.Now.AddDays(-3), ModifiedAt = DateTime.Now.AddDays(-3), Interest = courseDataService.GetAllCoursesAsync().Result[10], Notes = "Qarshidan. Veb-saytdan topgan. Ingliz tili kursiga qiziqmoqda." },
        new() { Id = 12, Name = "Nodira Azizova", Email = "nodira.azizova@example.com", Phone = "+998 91 345 67 89", Status = LeadStatus.Contacted, Source = LeadSource.Referral, CreatedAt = DateTime.Now.AddDays(-2), ModifiedAt = DateTime.Now.AddDays(-2), Interest = courseDataService.GetAllCoursesAsync().Result[11], Notes = "Urganch. Do'sti tavsiya qilgan. Business English kursiga qiziqish bildirdi." },
        new() { Id = 13, Name = "Jamshid Toshpulatov", Email = "jamshid.toshpulatov@example.com", Phone = "+998 92 456 78 90", Status = LeadStatus.NoContact, Source = LeadSource.SocialMedia, CreatedAt = DateTime.Now.AddDays(-1), ModifiedAt = DateTime.Now.AddDays(-1), Interest = courseDataService.GetAllCoursesAsync().Result[12], Notes = "Termizdan. Facebook orqali topgan. English Conversation kursiga qiziqmoqda." },
        new() { Id = 14, Name = "Shahzoda Yusupova", Email = "shahzoda.yusupova@example.com", Phone = "+998 93 567 89 01", Status = LeadStatus.Lost, Source = LeadSource.Advertisement, CreatedAt = DateTime.Now.AddDays(-30), ModifiedAt = DateTime.Now.AddDays(-30), Interest = courseDataService.GetAllCoursesAsync().Result[13], Notes = "Andijondan. Reklama orqali topgan, lekin moliyaviy qiyinchiliklar tufayli qatnasha olmaydi." },
        new() { Id = 15, Name = "Ravshan Komilov", Email = "ravshan.komilov@example.com", Phone = "+998 94 678 90 12", Status = LeadStatus.Acquired, Source = LeadSource.Website, CreatedAt = DateTime.Now.AddDays(-28), ModifiedAt = DateTime.Now.AddDays(-28), Interest = courseDataService.GetAllCoursesAsync().Result[14], Notes = "Samarqanddan. Veb-saytdan topgan. IELTS tayyorgarlik kursiga yozildi." },
        new() { Id = 16, Name = "Lola Ahmedova", Email = "lola.ahmedova@example.com", Phone = "+998 95 789 01 23", Status = LeadStatus.Created, Source = LeadSource.SocialMedia, CreatedAt = DateTime.Now.AddDays(-26), ModifiedAt = DateTime.Now.AddDays(-26), Interest = courseDataService.GetAllCoursesAsync().Result[0], Notes = "Buxorodan. Instagram orqali topgan. Web dasturlash kursiga qiziqmoqda." },
        new() { Id = 17, Name = "Timur Rasulov", Email = "timur.rasulov@example.com", Phone = "+998 96 890 12 34", Status = LeadStatus.Contacted, Source = LeadSource.Referral, CreatedAt = DateTime.Now.AddDays(-24), ModifiedAt = DateTime.Now.AddDays(-24), Interest = courseDataService.GetAllCoursesAsync().Result[1], Notes = "Nukusdan. Do'sti tavsiya qilgan. Advanced Web Development kursiga qiziqish bildirdi." },
        new() { Id = 18, Name = "Kamola Sattorova", Email = "kamola.sattorova@example.com", Phone = "+998 97 901 23 45", Status = LeadStatus.NoContact, Source = LeadSource.Website, CreatedAt = DateTime.Now.AddDays(-22), ModifiedAt = DateTime.Now.AddDays(-22), Interest = courseDataService.GetAllCoursesAsync().Result[2], Notes = "Qo'qondan. Veb-saytdan topgan. Data Science kursiga qiziqmoqda." },
        new() { Id = 19, Name = "Oybek Mirzayev", Email = "oybek.mirzayev@example.com", Phone = "+998 98 012 34 56", Status = LeadStatus.Lost, Source = LeadSource.Advertisement, CreatedAt = DateTime.Now.AddDays(-20), ModifiedAt = DateTime.Now.AddDays(-20), Interest = courseDataService.GetAllCoursesAsync().Result[3], Notes = "Marg'ilondan. Reklama orqali topgan, lekin boshqa kursga yozilishga qaror qildi." },
        new() { Id = 20, Name = "Nargiza Umarova", Email = "nargiza.umarova@example.com", Phone = "+998 99 123 45 67", Status = LeadStatus.Acquired, Source = LeadSource.SocialMedia, CreatedAt = DateTime.Now.AddDays(-18), ModifiedAt = DateTime.Now.AddDays(-18), Interest = courseDataService.GetAllCoursesAsync().Result[4], Notes = "Toshkentdan. Facebook orqali topgan. Mobile App Development kursiga yozildi." },
        new() { Id = 21, Name = "Alisher Qodirov", Email = "alisher.qodirov@example.com", Phone = "+998 90 234 56 78", Status = LeadStatus.Created, Source = LeadSource.Website, CreatedAt = DateTime.Now.AddDays(-16), ModifiedAt = DateTime.Now.AddDays(-16), Interest = courseDataService.GetAllCoursesAsync().Result[5], Notes = "Andijandan. Veb-saytdan topgan. Cybersecurity kursiga qiziqmoqda." },
        new() { Id = 22, Name = "Feruza Rahimova", Email = "feruza.rahimova@example.com", Phone = "+998 91 345 67 89", Status = LeadStatus.Contacted, Source = LeadSource.Referral, CreatedAt = DateTime.Now.AddDays(-14), ModifiedAt = DateTime.Now.AddDays(-14), Interest = courseDataService.GetAllCoursesAsync().Result[6], Notes = "Namangandan. Do'sti tavsiya qilgan. Cloud Computing kursiga qiziqish bildirdi." },
        new() { Id = 23, Name = "Sherzod Yusupov", Email = "sherzod.yusupov@example.com", Phone = "+998 92 456 78 90", Status = LeadStatus.NoContact, Source = LeadSource.SocialMedia, CreatedAt = DateTime.Now.AddDays(-12), ModifiedAt = DateTime.Now.AddDays(-12), Interest = courseDataService.GetAllCoursesAsync().Result[7], Notes = "Xorazmdan. Instagram orqali topgan. Database Management kursiga qiziqmoqda." },
        new() { Id = 24, Name = "Maftuna Azimova", Email = "maftuna.azimova@example.com", Phone = "+998 93 567 89 01", Status = LeadStatus.Lost, Source = LeadSource.Advertisement, CreatedAt = DateTime.Now.AddDays(-10), ModifiedAt = DateTime.Now.AddDays(-10), Interest = courseDataService.GetAllCoursesAsync().Result[8], Notes = "Jizzaxdan. Reklama orqali topgan, lekin kurs jadvali mos kelmadi." },
        new() { Id = 25, Name = "Ulug'bek Tursunov", Email = "ulugbek.tursunov@example.com", Phone = "+998 94 678 90 12", Status = LeadStatus.Acquired, Source = LeadSource.Website, CreatedAt = DateTime.Now.AddDays(-8), ModifiedAt = DateTime.Now.AddDays(-8), Interest = courseDataService.GetAllCoursesAsync().Result[9], Notes = "Qarshidan. Veb-saytdan topgan. DevOps Practices kursiga yozildi." },
        new() { Id = 26, Name = "Dilshoda Karimova", Email = "dilshoda.karimova@example.com", Phone = "+998 95 789 01 23", Status = LeadStatus.Created, Source = LeadSource.SocialMedia, CreatedAt = DateTime.Now.AddDays(-6), ModifiedAt = DateTime.Now.AddDays(-6), Interest = courseDataService.GetAllCoursesAsync().Result[10], Notes = "Farg'onadan. Facebook orqali topgan. English for Beginners kursiga qiziqmoqda." },
        new() { Id = 27, Name = "Bobur Aliyev", Email = "bobur.aliyev@example.com", Phone = "+998 96 890 12 34", Status = LeadStatus.Contacted, Source = LeadSource.Referral, CreatedAt = DateTime.Now.AddDays(-4), ModifiedAt = DateTime.Now.AddDays(-4), Interest = courseDataService.GetAllCoursesAsync().Result[11], Notes = "Samarqanddan. Do'sti tavsiya qilgan. Business English kursiga qiziqish bildirdi." },
        new() { Id = 28, Name = "Nilufar Saidova", Email = "nilufar.saidova@example.com", Phone = "+998 97 901 23 45", Status = LeadStatus.NoContact, Source = LeadSource.Website, CreatedAt = DateTime.Now.AddDays(-2), ModifiedAt = DateTime.Now.AddDays(-2), Interest = courseDataService.GetAllCoursesAsync().Result[12], Notes = "Buxorodan. Veb-saytdan topgan. English Conversation kursiga qiziqmoqda." },
        new() { Id = 29, Name = "Jasur Rahmonov", Email = "jasur.rahmonov@example.com", Phone = "+998 98 012 34 56", Status = LeadStatus.Lost, Source = LeadSource.Advertisement, CreatedAt = DateTime.Now.AddDays(-1), ModifiedAt = DateTime.Now.AddDays(-1), Interest = courseDataService.GetAllCoursesAsync().Result[13], Notes = "Navoiydan. Reklama orqali topgan, lekin boshqa ta'lim markazini tanladi." },
        new() { Id = 30, Name = "Madina Usmonova", Email = "madina.usmonova@example.com", Phone = "+998 99 123 45 67", Status = LeadStatus.Acquired, Source = LeadSource.SocialMedia, CreatedAt = DateTime.Now.AddDays(-30), ModifiedAt = DateTime.Now.AddDays(-30), Interest = courseDataService.GetAllCoursesAsync().Result[14], Notes = "Toshkentdan. Instagram orqali topgan. IELTS Preparation kursiga yozildi." },
    ];
}
