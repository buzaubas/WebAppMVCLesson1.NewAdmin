﻿using System;
using System.Collections.Generic;

namespace WebAppMVCLesson1.NewAdmin.Modals;

public partial class Carusel
{
    public int CaruselId { get; set; }

    public string? Tirle { get; set; }

    public string? Description { get; set; }

    public string? PictureUrl { get; set; }

    public DateTime? CreateDate { get; set; }

    public string? CreateUser { get; set; }

    public DateTime? ExpireDate { get; set; }
}
